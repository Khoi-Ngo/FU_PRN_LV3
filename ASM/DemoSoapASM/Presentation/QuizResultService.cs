using QuizResultServiceReference;
using System.ServiceModel;

namespace Presentation
{
    public class QuizResultService
    {
        private readonly QuizResultSoapServiceClient _client;

        public QuizResultService()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("https://localhost:7139/PremaritalCounselingSoapService.asmx");
            _client = new QuizResultSoapServiceClient(binding, endpoint);
        }

        public async Task<List<QuizResultModel>> GetAllAsync()
        {
            var results = await _client.GetAllAsync();
            return results.Select(MapToLocalModel).ToList();
        }

        public async Task<QuizResultModel> GetByIdAsync(long id)
        {
            var result = await _client.GetByIdAsync(id);
            return MapToLocalModel(result);
        }

        public async Task<int> CreateAsync(QuizResultCreateModel model)
        {
            var wcfModel = MapToWcfCreateModel(model);
            return await _client.CreateAsync(wcfModel);
        }

        public async Task<int> UpdateAsync(QuizResultModel model)
        {
            var wcfModel = MapToWcfModel(model);
            return await _client.UpdateAsync(wcfModel);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _client.DeleteAsync(id);
        }

        public async Task<List<QuizResultModel>> SearchAsync(string qzcode, string sugContent, string feedback)
        {
            var results = await _client.SearchAsync(qzcode, sugContent, feedback);
            return results.Select(MapToLocalModel).ToList();
        }

        public async Task<string> GetChatBotResponseAsync(string message)
        {
            return await _client.GetChatBotResponseAsync(message);
        }

        // Mapping methods
        private QuizResultModel MapToLocalModel(QuizResultServiceReference.QuizResultModel wcfModel)
        {
            if (wcfModel == null) return null;
            return new QuizResultModel
            {
                Id = wcfModel.Id,
                Score = wcfModel.Score,
                QuizId = wcfModel.QuizId,
                UserId = wcfModel.UserId,
                QuizResultCode = wcfModel.QuizResultCode,
                TimeCompleted = wcfModel.TimeCompleted,
                AttemptTime = wcfModel.AttemptTime,
                DoHaveFeedback = wcfModel.DoHaveFeedback,
                FeedBack = wcfModel.FeedBack,
                SuggestionContent = wcfModel.SuggestionContent,
                UserAnswerData = wcfModel.UserAnswerData,
                RecommendedAnswerData = wcfModel.RecommendedAnswerData,
                CreatedAt = wcfModel.CreatedAt,
                ModifiedAt = wcfModel.ModifiedAt,
                CreatedBy = wcfModel.CreatedBy,
                ModifiedBy = wcfModel.ModifiedBy,
                IsActive = wcfModel.IsActive,
                IsDeleted = wcfModel.IsDeleted
            };
        }

        private QuizResultServiceReference.QuizResultModel MapToWcfModel(QuizResultModel localModel)
        {
            if (localModel == null) return null;
            return new QuizResultServiceReference.QuizResultModel
            {
                Id = localModel.Id,
                Score = localModel.Score,
                QuizId = localModel.QuizId,
                UserId = localModel.UserId,
                QuizResultCode = localModel.QuizResultCode,
                TimeCompleted = localModel.TimeCompleted,
                AttemptTime = localModel.AttemptTime,
                DoHaveFeedback = localModel.DoHaveFeedback,
                FeedBack = localModel.FeedBack,
                SuggestionContent = localModel.SuggestionContent,
                UserAnswerData = localModel.UserAnswerData,
                RecommendedAnswerData = localModel.RecommendedAnswerData,
                CreatedAt = localModel.CreatedAt,
                ModifiedAt = localModel.ModifiedAt,
                CreatedBy = localModel.CreatedBy,
                ModifiedBy = localModel.ModifiedBy,
                IsActive = localModel.IsActive,
                IsDeleted = localModel.IsDeleted
            };
        }

        private QuizResultServiceReference.QuizResultCreateModel MapToWcfCreateModel(QuizResultCreateModel localModel)
        {
            if (localModel == null) return null;
            return new QuizResultServiceReference.QuizResultCreateModel
            {
                Score = localModel.Score,
                QuizId = localModel.QuizId,
                UserId = localModel.UserId,
                QuizResultCode = localModel.QuizResultCode,
                TimeCompleted = localModel.TimeCompleted,
                AttemptTime = localModel.AttemptTime,
                DoHaveFeedback = localModel.DoHaveFeedback,
                FeedBack = localModel.FeedBack,
                SuggestionContent = localModel.SuggestionContent,
                UserAnswerData = localModel.UserAnswerData,
                RecommendedAnswerData = localModel.RecommendedAnswerData
            };
        }
    }
}