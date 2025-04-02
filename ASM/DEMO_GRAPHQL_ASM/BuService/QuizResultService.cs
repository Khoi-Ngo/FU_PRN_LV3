using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Repositories;

namespace BuService
{
    public interface IQuizResultService
    {
        Task<QuizResult> GetQuizResultSimplyAsync(long id);
        Task<List<QuizResult>> GetQuizResultsSimplyAsync();
        Task<bool> DeleteQuizResultSimplyAsync(long id);
        Task<int> CreateQuizResultSimplyAsync(QuizResult request);
        Task<int> UpdateQuizResultSimplyAsync(QuizResult request);
        Task<List<User>> GetViewBagUser();
        Task<List<Quiz>> GetViewBagQuiz();
    }
    public class QuizResultService : IQuizResultService
    {
        private readonly QuizRepository _quizRepository;
        private readonly QuizResultRepository _quizResultRepository;
        private readonly UserRepository _userRepository;

        public QuizResultService()
        {
            _quizRepository ??= new QuizRepository();
            _quizResultRepository ??= new QuizResultRepository();
            _userRepository ??= new UserRepository();
        }

        public async Task<int> CreateQuizResultSimplyAsync(QuizResult request)
        {

            return await _quizResultRepository.CreateAsync(request);
        }

        public async Task<bool> DeleteQuizResultSimplyAsync(long id)
        {
            //get if any
            var deletedE = await _quizResultRepository.GetByIdAsync(id);
            if (deletedE == null)
            {
                throw new Exception("There is no Quiz Result found");
            }
            return await _quizResultRepository.RemoveAsync(deletedE);
        }

        public async Task<QuizResult> GetQuizResultSimplyAsync(long id)
        {
            return await _quizResultRepository.GetByIdAsync2(id);
        }

        public async Task<List<QuizResult>> GetQuizResultsSimplyAsync()
        {
            return await _quizResultRepository.GetAllAsync2();
        }

        public async Task<List<Quiz>> GetViewBagQuiz()
        {
            return await _quizRepository.GetAllAsync();
        }

        public async Task<List<User>> GetViewBagUser()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<int> UpdateQuizResultSimplyAsync(QuizResult request)
        {
            //get if any
            var updatedE = await _quizResultRepository.GetByIdAsync(request.Id);
            if (updatedE == null)
            {
                throw new Exception("There is no Quiz Result found");
            }
            //setting new fields

            //SCORE
            updatedE.Score = request.Score;

            //QUIZ ID
            updatedE.QuizId = request.QuizId;
            //USER ID
            updatedE.UserId = request.UserId;
            //QRCODE optional
            updatedE.QuizResultCode = !string.IsNullOrEmpty(request.QuizResultCode) ? request.QuizResultCode : updatedE.QuizResultCode;
            //TIMECOMPLETED optional
            updatedE.TimeCompleted = request.TimeCompleted == null ? updatedE.TimeCompleted : request.TimeCompleted;

            //ATTEMP TIME optional
            updatedE.AttemptTime = request.AttemptTime == null ? updatedE.AttemptTime : request.AttemptTime;
            //DO HAVE FEEDBACK
            updatedE.DoHaveFeedback = request.DoHaveFeedback == null ? updatedE.DoHaveFeedback : request.DoHaveFeedback;
            //FEEDBACK
            updatedE.FeedBack = !string.IsNullOrEmpty(request.FeedBack) ? request.FeedBack : updatedE.FeedBack;
            //SUGGESTION CONTENT
            updatedE.SuggestionContent = !string.IsNullOrEmpty(request.SuggestionContent) ? request.SuggestionContent : updatedE.SuggestionContent;

            //USER ANSWER DATA
            updatedE.UserAnswerData = !string.IsNullOrEmpty(request.UserAnswerData) ? request.UserAnswerData : updatedE.UserAnswerData;

            //REC ANSWER DATA
            updatedE.RecommendedAnswerData = !string.IsNullOrEmpty(request.RecommendedAnswerData) ? request.RecommendedAnswerData : updatedE.RecommendedAnswerData;

            //MODIFY AT
            updatedE.ModifiedAt = DateTime.Now;


            //continue to save into the database
            return await _quizResultRepository.UpdateAsync(updatedE);
        }



    }
}
