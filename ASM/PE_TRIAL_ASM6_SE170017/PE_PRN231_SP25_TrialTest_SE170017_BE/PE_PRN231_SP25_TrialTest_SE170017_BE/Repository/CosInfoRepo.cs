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
                .OrderByDescending(x => x.CosmeticId).ToListAsync();
        }

        //return await _context.CosmeticInformations.Include(x => x.Category.CategoryName).ToListAsync();


        public async Task<CosmeticInformation> GetByIdAsync2(string id)
        {
            return await _context.CosmeticInformations.Include(x => x.Category).FirstOrDefaultAsync(x => x.CosmeticId == id);

        }

        public async Task<object?> SearchAsync(string item1, string item2, string item3)
        {
            var res = await _context.CosmeticInformations
                .Where(x =>
                                x.CosmeticName.Contains(item1) &&
                    x.CosmeticSize.Contains(item3) &&
                    x.SkinType.Contains(item2))
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
                .GroupBy(x => new { x.CosmeticName, x.CosmeticSize, x.SkinType })
                .Select(group => new
                {
                    CosmeticName = group.Key.CosmeticName,
                    CosmeticSize = group.Key.CosmeticSize,
                    SkinType = group.Key.SkinType,
                    Items = group.ToList() // Convert group to list
                })
                .ToListAsync();

            return res;
        }

        public async Task<object?> SearchAsync2(string item1, string item2, string item3)
        {
            var res = await _context.CosmeticInformations
                .Where(x =>
                    x.CosmeticName.Contains(item1) &&
                    x.CosmeticSize.Contains(item3) &&
                    x.SkinType.Contains(item2))
                //.Select(x => new
                //{
                //    x.CosmeticId,
                //    x.CosmeticName,
                //    x.SkinType,
                //    x.ExpirationDate,
                //    x.CosmeticSize,
                //    x.DollarPrice,
                //    x.CategoryId,
                //    CategoryName = x.Category.CategoryName
                //})
                .OrderBy(x => x.CosmeticName)  // Ordering by CosmeticName first
                .ThenBy(x => x.SkinType)       // Then ordering by SkinType
                .ThenBy(x => x.CosmeticSize)   // Then ordering by CosmeticSize
                .ToListAsync();

            return res; // Returning as object (anonymous type collection)
        }

    }
}
