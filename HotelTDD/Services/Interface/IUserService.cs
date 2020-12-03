using HotelTDD.Services.User.Request;
using HotelTDD.Services.User.Response;

namespace HotelTDD.Services.Interface
{
    public interface IUserService
    {
        void CreateUser(UserCreateRequest user);
        UserLoginResponse Login(UserLoginRequest user);
    }
}
