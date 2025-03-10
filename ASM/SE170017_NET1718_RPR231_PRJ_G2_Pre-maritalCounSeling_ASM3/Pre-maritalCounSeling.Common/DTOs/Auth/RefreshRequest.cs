using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.Common.DTOs.Auth
{
    public class RefreshRequest
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
