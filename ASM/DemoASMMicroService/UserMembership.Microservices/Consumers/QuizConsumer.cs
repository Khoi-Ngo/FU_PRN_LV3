using MassTransit;
using Micro1.Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Micro1.UserMembership.MicroServices.Consumers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizConsumer : IConsumer<BusinessObject.Shared.Models.Quiz>
    {
        private readonly ILogger _logger;

        public QuizConsumer(ILogger<QuizConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BusinessObject.Shared.Models.Quiz> context)
        {
        https://localhost:7125/gateway/Quiz

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
                string messageLog = string.Format("[{0}] PUBLISH data from RabbitMQ.quizResultQueue: {1}", DateTime.Now.ToString(), Utilities.ConvertObjectToJSONString(data));

                Utilities.WriteLoggerFile(messageLog);

                _logger.LogInformation(messageLog);

            }

            #endregion

        }
    }
}

