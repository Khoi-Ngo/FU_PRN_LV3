using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessService
{
    public class MainService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AccountRepo accountRepo;
        private readonly CateRepo cateRepo;
        private readonly CosInfoRepo cosInfoRepo;

        public MainService(IHttpContextAccessor httpContextAccessor, AccountRepo accountRepo, CateRepo cateRepo, CosInfoRepo cosInfoRepo)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.accountRepo = accountRepo;
            this.cateRepo = cateRepo;
            this.cosInfoRepo = cosInfoRepo;
        }

        public async Task CreateAsync(CosmeticInformation request)
        {
            await cosInfoRepo.CreateAsync(request);
        }

        public async Task DeleteAsync(string id)
        {
            var res = await cosInfoRepo.GetByIdAsync(id);
            await cosInfoRepo.RemoveAsync(res);
        }

        public async Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<object?> GetAllAsync()
        {
            return await cosInfoRepo.GetAllAsync2();
        }

        public async Task<CosmeticInformation> GetDetailAsync(string id)
        {
            return await cosInfoRepo.GetByIdAsync2(id);
        }

        public async Task<object?> GetDetailAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<object?> LoginAsync(string userName, string password)
        {
            var user = await accountRepo.GetUser(userName, password);
            var accessToken = GenerateAccessToken(user);
            return new { token = "Bearer " + accessToken };
        }

        public async Task UpdateAsync(CosmeticInformation request)
        {
            await cosInfoRepo.UpdateAsync(request);
        }

        #region AUTH JWT


        public string GenerateAccessToken(SystemAccount user)
        {
            //Claim attribute for the token
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.AccountId.ToString()),
                new Claim("RoleSave", user.Role.ToString()),
                new Claim("Email", user.EmailAddress)

                //Other claim
                

            };
            //get secretkey for jwt token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PE-PRN333SESE-JWTBearerSecretKey"));

            //create credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<object?> SearchAsync(string item1, string item2, string item3)
        {
            return await cosInfoRepo.SearchAsync(
                item1 != null ? item1 : "",
                item2 != null ? item2 : "",
                item3 != null ? item3 : ""
                );
        }

        public async Task<object?> GetViewBag()
        {
            return (await cateRepo.GetAllAsync()).Select(x => x.CategoryId).ToList();
        }

        public async Task<object?> SearchAsync2(string item1, string item2, string item3)
        {
            var response = await cosInfoRepo.SearchAsync2(
                item1 ?? "",
                item2 ?? "",
                item3 ?? ""
            );

            return response;
        }



        #endregion
    }
}
