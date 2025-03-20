using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class CreateUpdateDTO
    {
        public string CosmeticId { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z][a-zA-Z0-9@#]*\s)*[A-Z][a-zA-Z0-9@#]*$",
            ErrorMessage = "Each word in CosmeticName must start with a capital letter and contain only letters, digits, spaces, @, or #.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "CosmeticName must be between 2 and 80 characters.")]
        public string CosmeticName { get; set; }

        [Required]
        public string SkinType { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "CosmeticSize must be between 2 and 80 characters.")]
        public string CosmeticSize { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "DollarPrice must be greater than 0.")]
        public decimal DollarPrice { get; set; }

        [Required]
        public string CategoryId { get; set; }
    }
}
