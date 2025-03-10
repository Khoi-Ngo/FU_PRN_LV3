using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.BAL.ServiceUser;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.APIService.GraphQLs
{
    public class Query
    {
        private readonly IQuizResultService _quizResultService;
        private readonly IUserService _userService;
        private readonly IQuizService _quizService;

        public Query(IQuizResultService quizResultService, IUserService userService, IQuizService quizService)
        {
            _quizResultService = quizResultService;
            _userService = userService;
            _quizService = quizService;
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
            }
            return null;
        }

       //TODO: Create


        //TODO: Detail


        //TODO: Update
    }
}
