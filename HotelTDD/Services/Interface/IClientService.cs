using HotelTDD.Services.Client.Request;
using HotelTDD.Services.Client.Response;

namespace HotelTDD.Services.Interface
{
    public interface IClientService
    {
        void Create(ClientCreateRequest request);
        ClientListResponse GetById(int id);
    }
}
