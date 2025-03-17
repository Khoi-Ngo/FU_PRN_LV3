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

namespace Pre_maritalCounSeling.DAL.Repositories.QuizRepo
{
    public class QuizResultRepository : GenericRepository<QuizResult>
    {
        private ILogger logger;
        private IHttpContextAccessor httpContextAccessor;

        public QuizResultRepository(NET1718_PRN231_PRJ_G2_PremaritalCounselingContext context) : base(context)
        {
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<ICollection<QuizResult>> GetAllWithQuizAsync()
        {
            return await _context.QuizResults.Include(r => r.Quiz).OrderByDescending(r => r.Id).ToListAsync();
        }
        public async Task<QuizResult> GetWithQuizAsync(long id)
        {
            return await _context.QuizResults.Include(r => r.Quiz).FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
