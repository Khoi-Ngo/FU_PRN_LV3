using Microsoft.EntityFrameworkCore;
using Pre_maritalCounSeling.DAL.Base;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.DAL.Repositories.UserRepo
{
    public class UserRepository : GenericRepository<User>
    {

        public UserRepository(NET1718_PRN231_PRJ_G2_PremaritalCounselingContext context) : base(context)
        { }

        public async Task<User> GetUser(string userName, string password)
            => await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);
        public async Task<User> GetByUserNameAsync(string userName)
           => await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == userName && u.IsActive == true);

        public async Task<List<User>> Search(string item1, string item2)
        {
            throw new NotImplementedException();
        }
        public async Task HandleRevokeTokenUser(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsDuplicateUser(string userName, string email)
        => await _context.Users.AnyAsync(u => u.UserName == userName || u.Email == email);

    }
}