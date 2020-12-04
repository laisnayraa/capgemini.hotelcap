using HotelTDD.Services.User.Request;
using HotelTDD.Services.User.Response;

namespace HotelTDD.Domain.Interface
{
    public interface IUserRepository
    {
        UserLoginResponse GetUser(UserLoginRequest user);
        void CreateUser(Users user);
    }
}
