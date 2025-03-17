
namespace Pre_maritalCounSeling.Common.DTOs
{
    public class GetQuizResultsResponse
    {
        public long Id { get; set; }

        public long Score { get; set; }

        public long QuizId { get; set; }

        public long UserId { get; set; }

        public string QuizResultCode { get; set; }

        public double TimeCompleted { get; set; }

        public long AttemptTime { get; set; } = 0;
        public bool DoHaveFeedback { get; set; }
        public string FeedBack { get; set; }

        public string SuggestionContent { get; set; }

        public string UserAnswerData { get; set; }// large text data
        public string RecommendedAnswerData { get; set; }// large text data
        public string QuizImg { get; set; }


    }
}
