using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepo : GenericRepository<SystemAccount>
    {
        public AccountRepo(Sp25CosmeticsDBContext context) : base(context)
        {
        }

        public async Task<SystemAccount> GetUser(string userName, string password)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(u => u.EmailAddress == userName && u.AccountPassword == password);

        }
    }
}
