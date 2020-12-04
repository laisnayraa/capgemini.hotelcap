using HotelTDD.Domain.Core;

namespace HotelTDD.Domain
{
    public class Users : DomainBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Users(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
