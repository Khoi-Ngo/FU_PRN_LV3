using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SHAREDMODEL.SoapModels
{
    [DataContract]
    public class QuizResultCreateModel
    {

        [DataMember]
        [Required]
        public long Score { get; set; }

        [DataMember]
        [Required]
        public long QuizId { get; set; }

        [DataMember]
        [Required]
        public long UserId { get; set; }

        [DataMember]
        public string? QuizResultCode { get; set; } = "RESULT-" + Guid.NewGuid().ToString();

        [DataMember]
        public double TimeCompleted { get; set; }

        [DataMember]
        public long? AttemptTime { get; set; } = 1;

        [DataMember]
        public bool? DoHaveFeedback { get; set; } = false;

        [DataMember]
        public string? FeedBack { get; set; }

        [DataMember]
        public string? SuggestionContent { get; set; } = "Unavailable yet";

        [DataMember]
        public string UserAnswerData { get; set; } // Large text data

        [DataMember]
        public string RecommendedAnswerData { get; set; } // Large text data

    }
}
