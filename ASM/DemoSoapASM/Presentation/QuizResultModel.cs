namespace Presentation
{
    public class QuizResultModel
    {
        public long Id { get; set; }
        public long Score { get; set; }
        public long QuizId { get; set; }
        public long UserId { get; set; }
        public string? QuizResultCode { get; set; }
        public double TimeCompleted { get; set; }
        public long? AttemptTime { get; set; }
        public bool? DoHaveFeedback { get; set; }
        public string? FeedBack { get; set; }
        public string? SuggestionContent { get; set; }
        public string UserAnswerData { get; set; }
        public string RecommendedAnswerData { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
