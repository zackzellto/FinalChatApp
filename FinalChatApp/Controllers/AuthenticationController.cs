using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalChatApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("success");
        }
    }
}