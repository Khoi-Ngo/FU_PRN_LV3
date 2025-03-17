using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLayer
{
    [DataContract]
    public class QuizResultDTOContract
    {
        public QuizResultDTOContract()
        {
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Score { get; set; }
        [DataMember]
        public long QuizId { get; set; }
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string QuizResultCode { get; set; } = "RESULT-" + Guid.NewGuid().ToString();
        [DataMember]
        public double TimeCompleted { get; set; }
        [DataMember]
        public long AttemptTime { get; set; } = 0;
        [DataMember]
        public bool DoHaveFeedback { get; set; }
        [DataMember]
        public string FeedBack { get; set; } // Expert or Admin can take time to give the feedback

        //Suggestion properties - AI Generated Only (can be updated no limit times)
        [DataMember]
        public string SuggestionContent { get; set; } = "Unavailable yet";
        [DataMember]
        public string UserAnswerData { get; set; }// large text data
        [DataMember]
        public string RecommendedAnswerData { get; set; }// large text data
    }
}
