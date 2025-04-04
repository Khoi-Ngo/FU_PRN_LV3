using Microsoft.AspNetCore.Mvc;
using BusinessObject.Shared.Models;
using MassTransit;
using MassTransit.Transports;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payment.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBus _bus;
        private readonly List<BusinessObject.Shared.Models.Payment> Payments;

        public PaymentController(ILogger<PaymentController> logger, IBus bus)
        {
            Payments = new()
            {
                new BusinessObject.Shared.Models.Payment
                {
                    PaymentId = 1,
                    PaymentDetailId = 1,
                    PaymentMethod = "Card",
                    Amount = 100.00,
                    PaymentDate = DateTime.Now,
                    Status = "Success",
                    TransactionId = "1",
                    PaymentReference = "REF006",
                    ProcessedBy = "Admin",
                    Remarks = "Payment for payment 123456",
                }

            };

            _logger = logger;
            _bus = bus;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<BusinessObject.Shared.Models.Payment> Get()
        {
            return Payments;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public BusinessObject.Shared.Models.Payment Get(int id)
        {
            return Payments.Find(p => p.PaymentId == id);
        }

        // POST api/<PaymentController>
        // Publish event to queue in event bus
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BusinessObject.Shared.Models.Payment payment)
        {
            if (payment != null)
            {
                #region Business rule process anh/or call other API Service

                #endregion

                #region Publish data to Queue on RabbitMQ

                //Lets Queue as paymentQueue.
                //Create a new URL ‘rabbitmq://localhost/paymentQueue’
                //If paymentQueue does not exist, RabbitMQ creates one
                Uri uri = new Uri("rabbitmq://localhost/paymentQueue");
                //Gets an endpoint to send the shared model object
                var endPoint = await _bus.GetSendEndpoint(uri);
                //Push the message to the queue 
                await endPoint.Send(payment);

                #endregion

                #region Logger

                string messageLog = string.Format("[{0}] PUBLISH data to RabbitMQ.paymentQueue: {1}", DateTime.Now, Common.Shared.Utilities.ConvertObjectToJSONString(payment));

                Common.Shared.Utilities.WriteLoggerFile(messageLog);
                _logger.LogInformation(messageLog);

                #endregion


                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
