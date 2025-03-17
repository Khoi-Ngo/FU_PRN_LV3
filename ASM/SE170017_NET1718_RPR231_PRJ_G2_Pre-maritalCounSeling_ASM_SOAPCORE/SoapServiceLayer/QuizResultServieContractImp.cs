using AutoMapper;
using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.DAL.Entities;
using System.ServiceModel;
namespace SoapServiceLayer
{
    public class QuizResultServieContractImp : QuizResultServiceContract
    {
        private readonly IQuizResultService _quizResultService;

        public QuizResultServieContractImp(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }

        public async Task<QuizResultDTOContract> GetQuizResultAsync(long quizResultId)
        {
            //get data from BAL
            QuizResult response = await _quizResultService.GetQuizResultAsync(quizResultId);

            //validate for FaultException
            if (response is null)
            {
                throw new FaultException<MissingQuizResultFault>(new MissingQuizResultFault($"A quiz result with ID {quizResultId} is missing."),
                    new FaultReason($"A quiz result with ID {quizResultId} is missing."),
                    new FaultCode("MissingQuizResult"), null);
            }

            //converting into the DTO Contract
            var quizResultDto = new QuizResultDTOContract
            {
                Id = response.Id,
                Score = response.Score,
                QuizId = response.QuizId,
                UserId = response.UserId,
                QuizResultCode = response.QuizResultCode,
                TimeCompleted = response.TimeCompleted,
                AttemptTime = response.AttemptTime,
                DoHaveFeedback = response.DoHaveFeedback,
                FeedBack = response.FeedBack,
                SuggestionContent = response.SuggestionContent,
                UserAnswerData = response.UserAnswerData,
                RecommendedAnswerData = response.RecommendedAnswerData
            };

            // Return DTO
            return quizResultDto;
        }
    }
}
