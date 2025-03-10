using Microsoft.AspNetCore.Http;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Infrastructure;

namespace Pre_maritalCounSeling.BAL.ServiceQuiz
{
    public interface IQuizService
    {
        Task<List<Quiz>> GetQuizzesAsync();
    }
    public class QuizService : IQuizService
    {
        #region INIT
        private readonly UnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuizService(UnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public async Task<List<Quiz>> GetQuizzesAsync()
        => await _unitOfWork.QuizRepository.GetAllAsync();
    }
}
