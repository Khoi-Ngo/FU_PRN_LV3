using GraphQL;
using GraphQL.Client.Abstractions;
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
        public async Task<QuizResult?> GetByIdAsync(string id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                    query QuizResultsDetailSimply($id: ID!) {
                        quizResultsDetailSimply(id: $id) {
                            id
                            score
                            userId
                            quizResultCode
                            quizId
                            timeCompleted
                            attemptTime
                            doHaveFeedback
                            feedBack
                            suggestionContent
                        }
                    }",
                    Variables = new { id = id }
                };

                var response = await _graphqlClient.SendQueryAsync<QuizResultDetailResponse>(graphQLRequest);
                return response?.Data?.QuizResultsDetailSimply;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching quiz result: {ex.Message}");
                return null;
            }
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
                    }"
                };

                var response = await _graphqlClient.SendQueryAsync<QuizResultResponse>(graphQLRequest);
                return response?.Data?.QuizResultsSimply ?? new List<QuizResult>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching quiz results: {ex.Message}");
                return new List<QuizResult>();
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                    mutation DeleteQuizResult($id: String!) {
                        deleteQuizResult(id: $id)
                    }",
                    Variables = new { id = id.ToString() }
                };

                var response = await _graphqlClient.SendMutationAsync<dynamic>(graphQLRequest);
                return response.Data.deleteQuizResult == true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting quiz result: {ex.Message}");
                return false;
            }
        }
    }

    // Response models

    public class QuizResultDetailResponse
    {
        public QuizResult? QuizResultsDetailSimply { get; set; }  // Changed from QuizResult to QuizResultsDetailSimply
    }
    public class QuizResultResponse
    {
        public List<QuizResult> QuizResultsSimply { get; set; } = new();
    }
}