using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Pre_maritalCounSeling.Common.Models.Auth;
using Pre_maritalCounSeling.Common.Util;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Repositories.UserRepo;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Pre_maritalCounSeling.BAL.Auth
{
    public class JWTService
    {
        #region INIT
        private readonly IConfiguration _configuration;
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JWTService(ILogger<JWTService> logger, IConfiguration configuration, UserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        //generating access token
        public string GenerateAccessToken(User user)
        {
            //Claim attribute for the token
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("FullName" +
                "", user.FullName),
                new Claim("Email", user.Email),
                new Claim("RoleName", user.Role.Name),
                new Claim("IsActive", user.IsActive.ToString()),
                new Claim("Avatar", user.Avatar),

            };
            //get secretkey for jwt token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Key"]));

            //create credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        //generating refresh token
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        //Get principal from token
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public async Task<AuthenticatedResponse> Refresh(RefreshRequest request)
        {
            var principal = GetPrincipalFromExpiredToken(request.AccessToken);
            string username = UserUtil.GetValueFromPrincipal(principal, "UserName").ToString();
            var user = await _userRepository.GetByUserNameAsync(username);
            //validate user token information
            //TODO: check expiryDateTime there is conflict insert datetime with read datetime
            if (user.RefreshToken != request.RefreshToken) throw new Exception("Invalid client request");
            //update user into database
            string newRefreshToken = GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userRepository.UpdateAsync(user);
            //return refresh response
            return new AuthenticatedResponse
            {
                AccessToken = GenerateAccessToken(user),
                RefreshToken = newRefreshToken,
                UserName = user.UserName,
                FullName = user.FullName,
                Avatar = user.Avatar
            };
        }

        public async Task HandleRevoke()
        {
            await _userRepository.HandleRevokeTokenUser(
                _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserName").Value);
        }

    }
}
