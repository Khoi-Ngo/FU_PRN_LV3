using Microsoft.EntityFrameworkCore;
using Pre_maritalCounSeling.DAL.Base;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.DAL.Repositories.UserRepo
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(NET1718_PRN231_PRJ_G2_PremaritalCounselingContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleByName(string roleName)
        => await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
    }
}
