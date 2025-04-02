using Microsoft.EntityFrameworkCore;
using Pre_maritalCounSeling.DAL.Base;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.DAL.Repositories
{
    public class QuizResultRepository : GenericRepository<QuizResult>
    {
        public QuizResultRepository()
        {
        }

        public async Task<List<QuizResult>> GetAllAsync2()
        {
            return await _context.QuizResults.Include(x => x.Quiz).Include(x => x.User).ToListAsync();
        }

        public async Task<QuizResult> GetByIdAsync2(long id)
        {
            return await _context.QuizResults.Include(x => x.Quiz).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
