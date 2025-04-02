using BuService;
using System.ServiceModel;
using System.Text.Json.Serialization;
using System.Text.Json;
using Pre_maritalCounSeling.DAL.Entities;
using System.Text;
using APISERVICESOAP.SoapModels;

namespace APISERVICESOAP.SoapService
{
    [ServiceContract]
    public interface IQuizResultSoapService
    {
        [OperationContract]
        Task<List<QuizResultModel>> GetAll();
        [OperationContract]
        Task<QuizResultModel> GetById(long id);
        [OperationContract]
        Task<int> Create(QuizResultCreateModel request);
        [OperationContract]
        Task<int> Update(QuizResultModel request);
        [OperationContract]
        Task<bool> Delete(long id);
        [OperationContract]
        Task<List<QuizResultModel>> Search(string qzcode, string sugContent, string feedback);
        [OperationContract]
        Task<string> GetChatBotResponse(string message);





    }
    public class QuizResultSoapService : IQuizResultSoapService
    {
        private readonly IQuizResultService _quizResultService;
        private readonly HttpClient _httpClient;

        public QuizResultSoapService(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public async Task<int> Create(QuizResultCreateModel request)
        {
            var opt = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            var quizResString = JsonSerializer.Serialize(request, opt);
            var item = JsonSerializer.Deserialize<QuizResult>(quizResString, opt);
            return await _quizResultService.CreateQuizResultSimplyAsync(item);
        }
        public async Task<int> Update(QuizResultModel request)
        {
            var opt = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            var quizResString = JsonSerializer.Serialize(request, opt);
            var item = JsonSerializer.Deserialize<QuizResult>(quizResString, opt);
            return await _quizResultService.UpdateQuizResultSimplyAsync(item);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                return await _quizResultService.DeleteQuizResultSimplyAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<QuizResultModel>> GetAll()
        {
            try
            {
                var items = await _quizResultService.GetQuizResultsSimplyAsync();

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                var itemsString = JsonSerializer.Serialize(items, opt);
                var result = JsonSerializer.Deserialize<List<QuizResultModel>>(itemsString, opt);

                return result;
            }
            catch (Exception ex)
            {
                return new List<QuizResultModel>();
            }
        }

        public async Task<QuizResultModel> GetById(long id)
        {
            try
            {
                var quizRes = await _quizResultService.GetQuizResultSimplyAsync(id);
                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                };
                var quizResString = JsonSerializer.Serialize(quizRes, opt);
                var item = JsonSerializer.Deserialize<QuizResultModel>(quizResString, opt);
                if (item != null)
                {
                    return await Task.FromResult(item);
                }
                else
                {
                    return new QuizResultModel();
                }
            }
            catch (Exception ex)
            {
                return new QuizResultModel();
            }
        }

        public async Task<List<QuizResultModel>> Search(string qzcode = "", string sugContent = "", string feedback = "")
        {
            try
            {
                var items = await _quizResultService.GetQuizResultsSimplyAsync();

                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                var itemsString = JsonSerializer.Serialize(items, opt);
                var result = JsonSerializer.Deserialize<List<QuizResultModel>>(itemsString, opt);

                //fitlering in case in the database having null value for those fields || DO LATER


                return result;

            }
            catch (Exception ex)
            {
                return new List<QuizResultModel>();
            }
        }



        //call API chat with GPT

        public async Task<string> GetChatBotResponse(string message)
        {
            try
            {
                // Prepare the request object
                var requestBody = new
                {
                    message = message
                };

                // Serialize the request to JSON
                var jsonContent = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make the POST request to the external API
                var response = await _httpClient.PostAsync("api/ChatBot", content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and parse the response
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<ChatBotResponse>(responseString);

                return responseObject?.response ?? "Sorry, I couldn't process your request.";
            }
            catch (Exception ex)
            {
                // Log the exception if you have a logging mechanism
                return "An error occurred while contacting the chat service.";
            }
        }
    }
    public class ChatBotResponse
    {
        public string response { get; set; }
    }
}
