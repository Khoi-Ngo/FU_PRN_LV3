namespace Pre_maritalCounSeling.Common.DTOs.Auth
{
    public class AuthenticatedResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        //OTHER PROPERTIES BELOW
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }
}
