using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalChatApp.Data;
using FinalChatApp.DTOs;
using FinalChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalChatApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AuthenticationController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public IActionResult Reister(RegisterDto dto)
        {
            var registerUser = new UserRegisterAndLogin
            {
                Username = dto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("User Registered Successfully", _repository.Create(registerUser));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            UserRegisterAndLogin? loginUser = _repository.GetByLogin(dto.Username);

            if (loginUser == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, loginUser.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            return Ok(loginUser);
        }
    }
}