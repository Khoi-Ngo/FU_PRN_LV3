

using BuService;
using Pre_maritalCounSeling.DAL.Entities;

namespace API_SERVICE.GraphQLs
{
    public class QuizResultQuery
    {
        private readonly IQuizResultService _quizResultService;

        public QuizResultQuery(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }

        public async Task<List<QuizResult>> GetQuizResultsSimplyAsync()
        {
            try
            {
                return await _quizResultService.GetQuizResultsSimplyAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot query : " + ex.Message);
            }
            return new List<QuizResult> { };
        }

        public async Task<QuizResult> GetQuizResultsDetailSimplyAsync(string id)
        {
            try
            {
                return await _quizResultService.GetQuizResultSimplyAsync(long.Parse(id));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot query : " + ex.Message);
            }
            return new QuizResult();
        }
    }
}
