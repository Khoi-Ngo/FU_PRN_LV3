using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro1.BusinessObject.Shared.Models
{
    public partial class Membership
    {
        [Key]
        public string MembershipId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int DurationMonths { get; set; }

        public int MaxChildren { get; set; }

        public string Features { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Quiz> UserMemberships { get; set; } = new List<Quiz>();
    }
}
