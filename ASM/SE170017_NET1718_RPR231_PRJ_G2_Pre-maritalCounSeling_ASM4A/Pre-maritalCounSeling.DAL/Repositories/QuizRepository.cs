using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pre_maritalCounSeling.DAL.Base;
using Pre_maritalCounSeling.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.DAL.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>
    {
        public QuizRepository()
        {
        }
    }
}
