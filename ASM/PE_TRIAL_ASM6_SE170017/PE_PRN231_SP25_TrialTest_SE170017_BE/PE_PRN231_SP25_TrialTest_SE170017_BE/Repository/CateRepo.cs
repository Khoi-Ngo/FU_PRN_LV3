using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CateRepo : GenericRepository<CosmeticCategory>
    {
        public CateRepo(Sp25CosmeticsDBContext context) : base(context)
        {
        }
    }
}
