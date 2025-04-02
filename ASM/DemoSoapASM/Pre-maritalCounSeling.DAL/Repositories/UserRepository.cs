using Microsoft.EntityFrameworkCore;
using Pre_maritalCounSeling.DAL.Base;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository()
        {
        }
    }
}