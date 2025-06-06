﻿namespace Presentation.GraphQL
{
    public class QuizResult
    {
        public long Id { get; set; }

        public long Score { get; set; }

        public long QuizId { get; set; }
        public long UserId { get; set; }

        public string QuizResultCode { get; set; } = "RESULT-" + Guid.NewGuid().ToString();

        public double TimeCompleted { get; set; }

        public long AttemptTime { get; set; } = 0;

        //Suggestion properties - AI Generated Only (can be updated no limit times)
        public string SuggestionContent { get; set; } = "Unavailable yet";
        public bool DoHaveFeedback { get; set; } = false;
        public string FeedBack { get; set; } = "Unavailable yet"; // Expert or Admin can take time to give the feedback
        public string UserAnswerData { get; set; } = "Unavailable yet";// large text data
        public string RecommendedAnswerData { get; set; } = "Unavailable yet";// large text data
        public string QuizImg { get; set; }


    }

}
