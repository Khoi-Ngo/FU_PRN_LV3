using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.Blazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        #region Fields and Constructor

        private readonly ILogger<ChatBotController> _logger;
        private readonly HttpClient _httpClient;

        public ChatBotController(ILogger<ChatBotController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            try
            {
                var _apiKey = "No haha";
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var requestBody = new
                {
                    model = "gpt-4o-mini",
                    messages = new[]
                    {
                        new { role = "user", content = request.Message }
                    }
                };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    _logger.LogError("OpenAI API call failed: {StatusCode}, Response: {Response}", response.StatusCode, errorResponse);
                    return StatusCode((int)response.StatusCode, "Error processing request.");
                }

                var resContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(resContent);
                var responseText = data?.choices?[0]?.message?.content?.ToString()?.Trim() ?? "No response received.";

                return Ok(new { response = responseText });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message to chatbot.");
                return StatusCode(500, new { message = "Error sending message to chatbot." });
            }
        }

        // Create a request model
        public class ChatRequest
        {
            public string Message { get; set; }
        }
    }
}
