namespace HotelTDD.Services.User.Request
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserLoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
