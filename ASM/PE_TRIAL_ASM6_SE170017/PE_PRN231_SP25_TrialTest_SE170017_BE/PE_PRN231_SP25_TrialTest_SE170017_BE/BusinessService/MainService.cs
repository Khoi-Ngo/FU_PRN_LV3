using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;
        private readonly AccountRepo accountRepo;
        private readonly CateRepo cateRepo;
        private readonly CosInfoRepo cosInfoRepo;

        public MainService(IConfiguration configuration, AccountRepo accountRepo, CateRepo cateRepo, CosInfoRepo cosInfoRepo)
        {
            this.accountRepo = accountRepo;
            this.cateRepo = cateRepo;
            this.cosInfoRepo = cosInfoRepo;
            this.configuration = configuration;
        }

        public async Task<object?> GetViewBag()
        {
            return (await cateRepo.GetAllAsync()).Select(x => x.CategoryId).ToList();
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
            //check exist
            var check = await cosInfoRepo.GetByIdAsync2(request.CosmeticId);
            if (check is null) throw new Exception("The updated data is not existed");
            await cosInfoRepo.UpdateAsync(request);
        }

        #region AUTH JWT


        public string GenerateAccessToken(SystemAccount user)
        {
            var secretKey = configuration["JWT:secretkey"];
            //Claim attribute for the token
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.AccountId.ToString()),
                new Claim("RoleSave", user.Role.ToString()),
                new Claim("Email", user.EmailAddress)

                //Other claim
                

            };
            //get secretkey for jwt token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

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


        #endregion

        #region increase the id in case the id is string and having no fields  to apply ordering by inserted time

        public async Task<CosmeticInformation> GetRequestWithId(CosmeticInformation request)
        {
            string topEID = (await cosInfoRepo.GetTopE()).CosmeticId;

            if (string.IsNullOrEmpty(topEID))
            {
                request.CosmeticId = "PL000001"; // Default 6 digits
                return request;
            }

            //check the format of the existed data
            string prefix = topEID.Substring(0, 2);
            int checkNoOfDigit = topEID.Substring(2).Length;
            int number = int.Parse(topEID.Substring(2));
            int newKeySubFixNumber = number + 1;

            if (newKeySubFixNumber == Math.Pow(10, checkNoOfDigit))
            {
                request.CosmeticId = prefix + newKeySubFixNumber.ToString();
                return request;
            }

            //StringBuilder str = new StringBuilder(Convert.ToString(newKeySubFixNumber));
            //while(str.Length < checkNoOfDigit)
            //{
            //    str.Insert(0, "0");
            //}
            //request.CosmeticId = str.ToString();
            //return request;
            // Format the new ID with leading zeros
            request.CosmeticId = prefix + newKeySubFixNumber.ToString("D" + checkNoOfDigit);
            return request;
        }

        #endregion


        #region Search
        public async Task<object?> SearchAsync(string item1, string item2, string item3)
        {
            return await cosInfoRepo.SearchAsync(
                item1 ?? "",
                item2 ?? "",
                item3 ?? ""
                );
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
