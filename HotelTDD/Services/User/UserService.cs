using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using HotelTDD.Configuration;
using HotelTDD.Domain.Interface;
using HotelTDD.Services.User.Response;
using HotelTDD.Services.User.Request;
using HotelTDD.Services.Interface;
using HotelTDD.Domain;

namespace HotelTDD.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserLoginResponse Login(UserLoginRequest request)
        {
            var result = _repository.GetUser(request);

            if (result != null)
            {
                result.Token = GenerateToken(result);
                result.Password = null;

                return result;
            }
            else
                throw new Exception("Login incorreto");
        }

        public void CreateUser(UserCreateRequest request)
        {
            var result = ValidateUser(request);

            if (result)
            {
                var user = new Users(request.Name, request.Email, request.Password, request.Role);
                _repository.CreateUser(user);
            }
                //_repository.CreateUser(request);
        }

        public string GenerateToken(UserLoginResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString().Trim()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool ValidateUser(UserCreateRequest user)
        {
            if (string.IsNullOrEmpty(user.Name))
                throw new Exception("Insira o nome de usuário");
            else if (string.IsNullOrEmpty(user.Email))
                throw new Exception("Insira o e-mail");
            else if (string.IsNullOrEmpty(user.Password))
                throw new Exception("Insira a senha");
            else if (string.IsNullOrEmpty(user.Role))
                throw new Exception("Insira o perfil do usuário");
            else
                return true;
        }
    }
}
