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
            var endpoint = new EndpointAddress("http://localhost:7139/PremaritalCounselingSoapService.asmx");
            _client = new QuizResultSoapServiceClient(binding, endpoint);
        }

        public async Task<List<QuizResultModel>> GetAllAsync()
        {
            var results = await _client.GetAllAsync();
            return results.ToList();
        }

        public async Task<QuizResultModel> GetByIdAsync(long id)
        {
            return await _client.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(QuizResultCreateModel model)
        {
            return await _client.CreateAsync(model);
        }

        public async Task<int> UpdateAsync(QuizResultModel model)
        {
            return await _client.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _client.DeleteAsync(id);
        }

        public async Task<List<QuizResultModel>> SearchAsync(string qzcode, string sugContent, string feedback)
        {
            return (await _client.SearchAsync(qzcode, sugContent, feedback)).ToList();
        }

        public async Task<string> GetChatBotResponseAsync(string message)
        {
            return await _client.GetChatBotResponseAsync(message);
        }
    }
}