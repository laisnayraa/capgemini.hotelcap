using HotelTDD.Domain.Interface;
using HotelTDD.Infra.Context;
using HotelTDD.Repository.Core;
using HotelTDD.Services.User.Request;
using HotelTDD.Services.User.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Repository
{
    public class UserRepository : RepositoryCore, IUserRepository
    {
        public UserRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }

        public void CreateUser(Domain.Users user)
        {
            _hotelContext.Add(user);
            _hotelContext.SaveChanges();
        }

        public UserLoginResponse GetUser(UserLoginRequest user)
        {
            var response = _hotelContext.User.AsNoTracking().Where(_ => _.Email == user.Email && _.Password == user.Password).FirstOrDefault();

            return new UserLoginResponse() {
                Name = response.Name,
                Email = response.Email,
                Password = user.Password,
                Role = response.Role
            };
        }
    }
}
