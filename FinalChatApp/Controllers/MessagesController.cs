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
    public class MessagesController : ControllerBase
    {
        static List<MessagesModel> messages = new List<MessagesModel>();

        // GET: api/Messages
        [HttpGet]
        public async Task<IEnumerable<MessagesModel>> Get()
        {
            var DBConnString = "Server=localhost;Port=5432;Database=ReactChatApp;User Id=postgres;Password=postgres;";

            await using var conn = new NpgsqlConnection(DBConnString);
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT * FROM messages", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                var messages = new List<MessagesModel>();
                while (await reader.ReadAsync())
                {
                    var message = new MessagesModel()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Message = reader.GetString(2),
                        Date_time = reader.GetDateTime(3)
                    };
                    messages.Add(message);
                }
            }

            return messages;
        }


        // POST: api/Messages
        [HttpPost]
        public void Post([FromBody] MessagesModel message)
        {
            messages.Add(message);
        }
    }
}
