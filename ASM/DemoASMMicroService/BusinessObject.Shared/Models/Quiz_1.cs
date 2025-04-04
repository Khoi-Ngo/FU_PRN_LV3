using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro1.BusinessObject.Shared.Models
{
    public partial class Quiz
    {
        public string UserMembershipId { get; set; }

        public string UserId { get; set; }

        public string MembershipId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PaymentStatus { get; set; }

        public decimal? PaymentAmount { get; set; }

        public string TransactionId { get; set; }

        public bool? AutoRenewal { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual User User { get; set; }
    }
}
