using BusinessObject.Shared.Models;
using Common.Shared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentDetail.Microservices.Consumers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultConsumer : IConsumer<BusinessObject.Shared.Models.QuizResult>
    {
        private readonly ILogger _logger;

        public QuizResultConsumer(ILogger<QuizResultConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BusinessObject.Shared.Models.QuizResult> context)
        {
            https://localhost:7199/gateway/quizresult

#region Receive data from Queue on RabbitMQ            

            var data = context.Message;

            #endregion

            #region Business rule process anh/or call other API Service

            //Validate the Data
            //Store to Database
            //Notify the user via Email / SMS

            #endregion

            #region Logger

            if (data != null)
            {
                string messageLog = string.Format("[{0}] RECEIVE data from RabbitMQ.paymentQueue: {1}", DateTime.Now.ToString(), Utilities.ConvertObjectToJSONString(data));

                Utilities.WriteLoggerFile(messageLog);

                _logger.LogInformation(messageLog);

            }

            #endregion

        }
    }
}
