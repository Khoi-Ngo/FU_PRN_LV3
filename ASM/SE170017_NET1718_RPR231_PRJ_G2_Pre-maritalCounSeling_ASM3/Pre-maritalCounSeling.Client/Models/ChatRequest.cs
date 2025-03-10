namespace Pre_maritalCounSeling.Client.Models
{
    public class ChatRequest
    {
        public string Message { get; set; }

        public ChatRequest(string message)
        {
            Message = message;
        }
    }
}
