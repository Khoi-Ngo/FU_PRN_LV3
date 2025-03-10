using System.Security.Claims;
using System.Text.RegularExpressions;
namespace Pre_maritalCounSeling.Common.Util
{
    public static class UserUtil
    {
        public static object GetValueFromPrincipal(ClaimsPrincipal principal, string name)
        {
            return principal.Claims.FirstOrDefault(c => c.Type == name)?.Value;
        }
        // Email regex validation
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }

        // Password regex validation (At least 8 characters, one uppercase, one lowercase, one number, and one special character)
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            var passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordRegex);
        }
    }
}
