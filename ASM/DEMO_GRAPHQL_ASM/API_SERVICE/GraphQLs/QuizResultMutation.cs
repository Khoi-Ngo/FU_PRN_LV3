using BuService;
using Pre_maritalCounSeling.DAL.Entities;
using System.Text;
using System.Text.Json;

namespace API_SERVICE.GraphQLs
{
    public class QuizResultMutation
    {
        private readonly IQuizResultService quizResultService;
        private readonly HttpClient httpClient;

        public QuizResultMutation(IQuizResultService quizResultService, HttpClient httpClient)
        {
            this.quizResultService = quizResultService;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }
        public async Task<ChatResponse> CallCHATGPT(ChatRequest request)
        {
            try
            {
                // Serialize the request object to JSON using JsonSerializer
                string jsonRequest = JsonSerializer.Serialize(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await httpClient.PostAsync("api/ChatBot", content);
                response.EnsureSuccessStatusCode();

                // Deserialize the response using JsonSerializer with case-insensitive options
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Handle case differences
                };
                ChatResponse chatResponse = JsonSerializer.Deserialize<ChatResponse>(jsonResponse, options);

                return chatResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to call ChatGPT API: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new Exception($"Failed to process ChatGPT response: {ex.Message}");
            }
        }
        public async Task<int> UpdateQuizResult(QuizResult request)
        {
            return await quizResultService.UpdateQuizResultSimplyAsync(request);
        }
        public async Task<int> AddQuizResult(QuizResult request)
        {
            var refinedRequest = new QuizResult
            {
                Score = request.Score,
                QuizId = request.QuizId,
                UserId = request.UserId,
                QuizResultCode = request.QuizResultCode ?? "RES-GRAP " + Guid.NewGuid().ToString(),
                TimeCompleted = request.TimeCompleted,
                UserAnswerData = request.UserAnswerData,
                RecommendedAnswerData = request.RecommendedAnswerData,
                FeedBack = request.FeedBack,
                SuggestionContent = request.SuggestionContent,
            };
            return await quizResultService.CreateQuizResultSimplyAsync(refinedRequest);
        }
        public async Task<bool> DeleteQuizResult(string id)
        {
            return await quizResultService.DeleteQuizResultSimplyAsync(long.Parse(id));
        }



       

    }
}