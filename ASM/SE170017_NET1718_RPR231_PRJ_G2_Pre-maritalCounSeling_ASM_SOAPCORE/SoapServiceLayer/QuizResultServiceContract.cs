using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoapServiceLayer
{
    [ServiceContract]
    public interface QuizResultServiceContract
    {
        [OperationContract]
        //[FaultContract(typeof())]
        Task<QuizResultDTOContract> GetQuizResultAsync(long quizResultId);

    }
}
