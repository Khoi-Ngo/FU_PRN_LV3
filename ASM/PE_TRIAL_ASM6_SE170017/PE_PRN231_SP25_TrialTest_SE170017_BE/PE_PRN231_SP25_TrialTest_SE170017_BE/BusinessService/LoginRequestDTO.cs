﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; } // can act as email
        public string Password { get; set; }
    }
}
