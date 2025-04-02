namespace Presentation
{
    public class QuizResultCreateModel
    {
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
    }
}
