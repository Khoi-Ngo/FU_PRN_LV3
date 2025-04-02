using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
namespace Presentation.GraphQL
{
    public class GraphQLConsumer
    {
        private static readonly string APIEndPoint = "https://localhost:7257/graphql/";
        private readonly GraphQLHttpClient _graphqlClient;

        public GraphQLConsumer()
        {
            _graphqlClient = new GraphQLHttpClient(APIEndPoint, new NewtonsoftJsonSerializer());
        }
        // In Presentation.GraphQL/GraphQLConsumer.cs
        public async Task<QuizResult> UpdateQuizResultAsync(QuizResult quizResult)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                mutation UpdateQuizResult($request: QuizResultInput!) {
                    updateQuizResult(request: $request)
                }",
                    Variables = new
                    {
                        request = new
                        {
                            id = quizResult.Id,
                            score = quizResult.Score,
                            quizId = quizResult.QuizId,
                            userId = quizResult.UserId,
                            quizResultCode = quizResult.QuizResultCode,
                            timeCompleted = quizResult.TimeCompleted,
                            userAnswerData = quizResult.UserAnswerData,
                            recommendedAnswerData = quizResult.RecommendedAnswerData,
                            feedBack = quizResult.FeedBack,
                            suggestionContent = quizResult.SuggestionContent
                        }
                    }
                };

                var response = await _graphqlClient.SendMutationAsync<dynamic>(graphQLRequest);
                return quizResult; // You might want to return the updated object from the server
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating quiz result: {ex.Message}");
                throw;
            }
        }

        public async Task<QuizResult> CreateQuizResultAsync(QuizResult quizResult)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                mutation AddQuizResult($request: QuizResultInput!) {
                    addQuizResult(request: $request)
                }",
                    Variables = new
                    {
                        request = new
                        {
                            id = 12,
                            score = quizResult.Score,
                            quizId = quizResult.QuizId,
                            userId = quizResult.UserId,
                            quizResultCode = quizResult.QuizResultCode,
                            timeCompleted = quizResult.TimeCompleted,
                            userAnswerData = quizResult.UserAnswerData,
                            recommendedAnswerData = quizResult.RecommendedAnswerData,
                            feedBack = quizResult.FeedBack,
                            suggestionContent = quizResult.SuggestionContent
                        }
                    }
                };

                var response = await _graphqlClient.SendMutationAsync<dynamic>(graphQLRequest);
                return quizResult; // You might want to return the created object with ID from the server
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating quiz result: {ex.Message}");
                throw;
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
       
        public async Task<QuizResult?> GetByIdAsync(string id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
            query QuizResultsDetailSimply($id: String!) {
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
                    createdAt
                    modifiedAt
                    createdBy
                    modifiedBy
                    isActive
                    isDeleted
                }
            }",
                    Variables = new { id = id }  // Ensure it's treated as a string
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
    }

    public class QuizResultDetailResponse
    {
        public QuizResult? QuizResultsDetailSimply { get; set; }  // Changed from QuizResult to QuizResultsDetailSimply
    }
    public class QuizResultResponse
    {
        public List<QuizResult> QuizResultsSimply { get; set; } = new();
    }





}