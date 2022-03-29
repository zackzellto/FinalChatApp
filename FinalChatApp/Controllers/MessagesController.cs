using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using FinalChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FinalChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MessagesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //static List<MessagesModel> messages = new();

        // GET: api/Messages
        [HttpGet]
        //public async Task<IEnumerable<MessagesModel>> GetAsync(int Id, string Username, string Message, DateTime Date_time)
        public JsonResult Get()
        {
            string messagesQuery = @"
                SELECT id as ""Id"",
                        username as ""Username"",
                        message as ""Message"",
                        date_time as ""Date_time""
                FROM messages";

            DataTable table = new DataTable();
            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
            NpgsqlDataReader messageReader;
            using NpgsqlConnection messageConnection = new NpgsqlConnection(DBConnectionString);
            messageConnection.Open();
            using (NpgsqlCommand messageCommand = new(messagesQuery, messageConnection))
            {
                messageReader = messageCommand.ExecuteReader();
                table.Load(messageReader);

                messageReader.Close();
                messageConnection.Close();
            }

            return new JsonResult(table);
        }
    }
}
            
        //    await using var conn = new NpgsqlConnection(DBConnString);
        //    await conn.OpenAsync();

        //    await using (var cmd = new NpgsqlCommand("SELECT * FROM messages", conn))
        //    await using (var reader = await cmd.ExecuteReaderAsync())
        //    {
        //        var messages = new List<MessagesModel>();
        //        while (await reader.ReadAsync())
        //        {
        //            var message = new MessagesModel()
        //            {
        //                Id = reader.GetInt32(0),
        //                Username = reader.GetString(1),
        //                Message = reader.GetString(2),
        //                Date_time = reader.GetDateTime(3)
        //            };
        //            messages.Add(message);
        //        }
        //    }

        //    return messages;
        //}


        // POST: api/Messages
        //[HttpPost]
        //public void Post([FromBody] MessagesModel message)
        //{
        //    messages.Add(message);
        //}
    //}
//}
