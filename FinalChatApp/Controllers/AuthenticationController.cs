using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalChatApp.Data;
using FinalChatApp.DTOs;
using FinalChatApp.Helpers;
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
        private readonly JwtService _jwtService;

        public AuthenticationController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
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

            var jwt = _jwtService.Generate(loginUser.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "User Logged In Successfully!"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "User Logged Out Successfully!"
            });
        }

    }
}