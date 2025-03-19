using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CosInfoRepo : GenericRepository<CosmeticInformation>
    {
        public CosInfoRepo(Sp25CosmeticsDBContext context) : base(context)
        {
        }

        public async Task<object> GetAllAsync2()
        {
            return await _context.CosmeticInformations
                .Select(x => new
                {
                    x.CosmeticId,
                    x.CosmeticName,
                    x.SkinType,
                    x.ExpirationDate,
                    x.CosmeticSize,
                    x.DollarPrice,
                    x.CategoryId,
                    CategoryName = x.Category.CategoryName
                })
                .ToListAsync();
        }

        //return await _context.CosmeticInformations.Include(x => x.Category.CategoryName).ToListAsync();


        public async Task<CosmeticInformation> GetByIdAsync2(string id)
        {
            return await _context.CosmeticInformations.Include(x => x.Category).FirstOrDefaultAsync(x => x.CosmeticId == id);

        }
    }
}
