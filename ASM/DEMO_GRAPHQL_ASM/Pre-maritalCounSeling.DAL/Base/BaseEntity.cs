using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.DAL.Base
{
    public class BaseEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
    }
}
