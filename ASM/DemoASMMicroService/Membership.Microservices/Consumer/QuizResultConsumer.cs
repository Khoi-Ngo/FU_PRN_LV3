using MassTransit;
using Micro1.Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Membership.Microservices.Consumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultConsumer : IConsumer<Micro1.BusinessObject.Shared.Models.QuizResult>
    {
        private readonly ILogger _logger;

        public QuizResultConsumer(ILogger<QuizResultConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Micro1.BusinessObject.Shared.Models.QuizResult> context)
        {
https://localhost:7125/gateway/QuizResult

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
                string messageLog = string.Format("[{0}] RECEIVE data from RabbitMQ.quizResultQueue: {1}", DateTime.Now.ToString(), Utilities.ConvertObjectToJSONString(data));

                Utilities.WriteLoggerFile(messageLog);

                _logger.LogInformation(messageLog);

            }

            #endregion

        }
    }
}
