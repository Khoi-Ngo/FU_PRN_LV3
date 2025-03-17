using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.BAL.ServiceUser;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.APIService.GraphQLs
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
                var temp = ex;
                throw new Exception("Cannot query : " + ex.Message);
            }
        }

       //TODO: Create


        //TODO: Detail


        //TODO: Update
    }
}
