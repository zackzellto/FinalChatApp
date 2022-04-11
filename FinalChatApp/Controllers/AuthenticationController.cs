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

            return Created("Success", _repository.Create(registerUser));
        }
    }
}