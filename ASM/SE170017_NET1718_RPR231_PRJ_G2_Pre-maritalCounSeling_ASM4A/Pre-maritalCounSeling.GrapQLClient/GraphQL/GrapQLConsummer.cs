using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Pre_maritalCounSeling.GrapQLClient.Models;

namespace Pre_maritalCounseling.GraphQLClient.GraphQL
{
    public class GraphQLConsumer
    {
        private static readonly string APIEndPoint = "https://localhost:7117/graphql/";
        private readonly GraphQLHttpClient _graphqlClient;

        public GraphQLConsumer()
        {
            _graphqlClient = new GraphQLHttpClient(APIEndPoint, new NewtonsoftJsonSerializer());
        }

        public async Task<List<QuizResult>> GetAllAsync()
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
query QuizResultsSimply {
    quizResultsSimply {
        id
        score
        quizId
        userId
        quizResultCode
        timeCompleted
        attemptTime
        doHaveFeedback
        feedBack
        suggestionContent
        userAnswerData
        recommendedAnswerData
        createdAt
        modifiedAt
        createdBy
        modifiedBy
        isActive
        isDeleted
    }
}
"
                };

                var response = await _graphqlClient.SendQueryAsync<QuizResultResponse>(graphQLRequest);
                var result = response?.Data?.QuizResultsSimply ?? new List<QuizResult>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching quiz results: {ex.Message}");
                return new List<QuizResult>();
            }
        }
    }

    public class QuizResultResponse
    {
        public List<QuizResult> QuizResultsSimply { get; set; } = new();
    }
}
