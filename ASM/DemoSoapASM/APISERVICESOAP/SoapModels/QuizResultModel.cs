using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace APISERVICESOAP.SoapModels
{
    [DataContract]
    public class QuizResultModel
    {
        [DataMember]
        public long Id { get; set; }

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

        [DataMember]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime? ModifiedAt { get; set; }

        [DataMember]
        public string? CreatedBy { get; set; }

        [DataMember]
        public string? ModifiedBy { get; set; }

        [DataMember]
        public bool? IsActive { get; set; } = true;

        [DataMember]
        public bool? IsDeleted { get; set; } = false;
    }
}
