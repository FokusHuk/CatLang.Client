namespace Catlang.Client.Contracts
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }

        public AuthenticationResponse(string username, string accessToken)
        {
            Username = username;
            AccessToken = accessToken;
        }
    }
}
