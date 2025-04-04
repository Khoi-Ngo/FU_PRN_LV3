using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Micro1.BusinessObject.Shared;
using Micro1.Common.Shared;

namespace Micro1.Membership.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly List<BusinessObject.Shared.Models.QuizResult> QuizResults;
        private readonly ILogger _logger;
        private readonly IBus _bus;

        public QuizResultController(IBus bus, ILogger<Micro1.BusinessObject.Shared.Models.QuizResult> logger)
        {
            _bus = bus;
            _logger = logger;

            QuizResults = new List<BusinessObject.Shared.Models.QuizResult>()
            {
                new BusinessObject.Shared.Models.QuizResult()
                {
                   Id = 1,
                   QuizResultCode = "DEMO CODE"
                },

            };
        }
        // GET: api/<MembershipController>
        [HttpGet]
        public IEnumerable<BusinessObject.Shared.Models.QuizResult> Get()
        {
            return QuizResults;
        }

        // GET api/<MembershipController>/5
        [HttpGet("{id}")]
        public BusinessObject.Shared.Models.QuizResult Get(long id)
        {
            return QuizResults.Find(b => b.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessObject.Shared.Models.QuizResult quizResult)
        {
            if (quizResult != null)
            {
                #region Business rule process anh/or call other API Service

                #endregion

                #region Publish data to Queue on RabbitMQ

                //Lets Queue as orderQueue.
                //Create a new URL ‘rabbitmq://localhost/orderQueue’
                //If orderQueue does not exist, RabbitMQ creates one
                Uri uri = new Uri("rabbitmq://localhost/quizResultQueue");
                //Gets an endpoint to send the shared model object
                var endPoint = await _bus.GetSendEndpoint(uri);
                //Push the message to the queue
                await endPoint.Send(quizResult);

                #endregion

                #region Logger

                string messageLog = string.Format("[{0}] PUBLISH data to RabbitMQ.quizResultQueue: {1}", DateTime.Now, Utilities.ConvertObjectToJSONString(quizResult));

                Utilities.WriteLoggerFile(messageLog);
                _logger.LogInformation(messageLog);

                #endregion


                return CreatedAtAction(nameof(Get), new { id = quizResult.Id }, quizResult);
            }
            return BadRequest();
        }

        // PUT api/<MembershipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MembershipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
