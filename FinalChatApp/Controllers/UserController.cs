using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace FinalChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<UserBCrypt> usersBCrypt = new();
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserBCrypt>> GetAsync(int Id, string Username, string Password)
        {
            var DBConnString = "Server=localhost;Port=5432;Database=ReactChatApp;User Id=postgres;Password=postgres;";
            var command = "SELECT * FROM public.users WHERE username=@username AND password=password";
            var users = new List<UserBCrypt>();

            await using var conn = new NpgsqlConnection(DBConnString);
            await conn.OpenAsync();

            NpgsqlParameter usrname = new()
            {
                ParameterName = "@username",
                NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                Direction = System.Data.ParameterDirection.Input,
                Value = Username
            };

            NpgsqlParameter usrname2 = new()
            {
                ParameterName = "@password",
                NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                Direction = System.Data.ParameterDirection.Input,
                Value = Password
            };


            await using (var cmd = new NpgsqlCommand(command, conn))
            {
                cmd.Parameters.Add(usrname);
                cmd.Parameters.Add(usrname2);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new UserBCrypt();
                        {
                            Id = reader.GetInt32(0);
                            Username = reader.GetString(1);
                            Password = reader.GetString(2);
                        };

                        usersBCrypt.Add(user);
                    }
                }
            }
            return users;
        }

        

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public int Get(int Id)
        {
            return Id;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] UserBCrypt user)
        {
            var isLoggedIn = new UserBCrypt()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            usersBCrypt.Add(isLoggedIn);

        }

    }
}
