using HotelTDD.Services.Interface;
using HotelTDD.Services.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelTDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Login Inválido.");

                var result = _service.Login(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel encontrar o login do usuário: {ex}");
            }
        }

        [HttpPost("createUser")]
        [Authorize(Roles = "ADM")]
        public IActionResult CreateUser([FromBody] UserCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Login Inválido.");

                _service.CreateUser(request);
                return Created("Usuário cadastrado.", request);

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel criar o usuário: {ex}");
            }
        }
    }
}
