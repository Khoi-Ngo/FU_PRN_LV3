using Pre_maritalCounSeling.BAL.Auth;
using Pre_maritalCounSeling.Common.Models.Auth;
using Pre_maritalCounSeling.Common.Util;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Infrastructure;
using Pre_maritalCounSeling.DAL.Repositories.UserRepo;

namespace Pre_maritalCounSeling.BAL.ServiceUser
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetById(int id);
        Task<int> Create(User User);
        Task<int> Update(User User);
        Task<bool> Delete(User User);
        Task<List<User>> Search(string item1, string item2);
        Task<AuthenticatedResponse> LoginAsync(string userName, string password);
        Task RegisterAsync(RegisterUserRequest request);
    }
    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork;
        private JWTService _jwtService;
        public UserService(UnitOfWork unitOfWork, JWTService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
        public async Task<int> Create(User User)
        {
            return await _unitOfWork.UserRepository.CreateAsync(User);
        }

        public async Task<bool> Delete(User User)
        {
            return await _unitOfWork.UserRepository.RemoveAsync(User);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<AuthenticatedResponse> LoginAsync(string userName, string password)
        {
            var user = await _unitOfWork.UserRepository.GetUser(userName, password);
            var response = new AuthenticatedResponse
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Avatar = user.Avatar,
                AccessToken = _jwtService.GenerateAccessToken(user),
                RefreshToken = _jwtService.GenerateRefreshToken(),
            };
            //save token data relating to the entity user
            await UpdateUserToken(user, response.RefreshToken);

            return response;
        }
        private async Task UpdateUserToken(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
            await _unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<List<User>> Search(string item1, string item2)
        {
            return await _unitOfWork.UserRepository.Search(item1, item2);
        }

        public Task<int> Update(User User)
        {
            //check active
            return _unitOfWork.UserRepository.UpdateAsync(User);
        }

        public async Task RegisterAsync(RegisterUserRequest request)
        {
            if (!await IsValidNewUser(request)) throw new Exception("Invalid user data");
            //save db
            _unitOfWork.UserRepository.Create(
                new User
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email,
                    FullName = request.FullName,
                    RoleId = (await GetUserRole(request.RoleName)).Id,
                    Phone = request.Phone,
                }
                );
        }
        private async Task<bool> IsValidNewUser(RegisterUserRequest request)
        {
            //validate data input
            if (UserUtil.IsValidEmail(request.Email) && UserUtil.IsValidPassword(request.Password))
            {
                //check duplicate email & username in db
                return !(await _unitOfWork.UserRepository.IsDuplicateUser(request.UserName, request.Email));
            }
            return false;
        }
        private async Task<Role> GetUserRole(string roleName) => await _unitOfWork.RoleRepository.GetRoleByName(roleName);
    }
}
