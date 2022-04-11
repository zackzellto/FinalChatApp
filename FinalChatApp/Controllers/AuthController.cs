using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FinalChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace FinalChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        //Register request
        [HttpPost("register")]

        //public JsonResult Post(User usr)
        //{
        //    string usersQuery = @"
        //        INSERT INTO users (username, password)
        //        VALUES (@username, @password)
        //    ";
        //    DataTable table = new DataTable();
        //    string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
        //    NpgsqlDataReader usersReader;
        //    using (NpgsqlConnection usersConnection = new NpgsqlConnection(DBConnectionString))
        //    {
        //        usersConnection.Open();
        //        using (NpgsqlCommand usersCommand = new(usersQuery, usersConnection))
        //        {

        //            usersCommand.Parameters.AddWithValue("@username", value: usr.Username);
        //            usersCommand.Parameters.AddWithValue("@password", value: usr.PasswordSalt);
        //            usersReader = usersCommand.ExecuteReader();
        //            table.Load(usersReader);

        //            usersReader.Close();
        //            usersConnection.Close();
        //        }
        //    }
        //    return new JsonResult("User Registered Successfully!");
        //}
        //public ActionResult<User> Register(UserRegisterAndLogin request)
        //{

        //    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //    user.Username = request.Username;
        //    //user.PasswordHash = passwordHash;
        //    //user.PasswordSalt = passwordSalt;

        //    return Ok(user);
        //}


        //Login request
        //[HttpPost("login")]
        //public ActionResult<string> Login(UserRegisterAndLogin request)
        //{
        //    if (user.Username != request.Username)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return BadRequest("Wrong Password.");
        //    }

        //    string token = CreateToken(user);
        //    return Ok(token);
        //}

        //Create JWT
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {

                new Claim(ClaimTypes.Name, user.Username),

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

        ////Create the hash using the hmac cryptography algorithm
        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {

        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        ////Verify input password gets hashed properly and checks against the algorithm to allow access.
        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        return computedHash.SequenceEqual(passwordHash);
        //    }
        //}
    }
}