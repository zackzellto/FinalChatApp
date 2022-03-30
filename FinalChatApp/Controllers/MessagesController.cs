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
using System.Text.Json.Serialization;
using System.Text.Json;

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

        // GET: api/Messages
        [HttpGet]
      
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
            using (NpgsqlConnection messageConnection = new NpgsqlConnection(DBConnectionString))
            {
                messageConnection.Open();
                using (NpgsqlCommand messageCommand = new(messagesQuery, messageConnection))
            {
                    messageReader = messageCommand.ExecuteReader();
                table.Load(messageReader);

                    messageReader.Close();
                messageConnection.Close();
                }
             }
            return new JsonResult(table);
        }

        // POST: api/Messages
        [HttpPost]
      
        public JsonResult Post(MessagesModel msg)
        {
            string messagesQuery = @"
                INSERT INTO messages (username, message)
                VALUES (@username, @message)
            ";
            DataTable table = new DataTable();
            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
            NpgsqlDataReader messageReader;
            using (NpgsqlConnection messageConnection = new NpgsqlConnection(DBConnectionString))
            {
                messageConnection.Open();
                using (NpgsqlCommand messageCommand = new(messagesQuery, messageConnection))
                {
                    messageCommand.Parameters.AddWithValue("@username", value: msg.Username);
                    messageCommand.Parameters.AddWithValue("@message", value: msg.Message);
                    messageReader = messageCommand.ExecuteReader();
                    table.Load(messageReader);

                    messageReader.Close();
                    messageConnection.Close();
                }
            }
            return new JsonResult("Entry added successfully!");
        }

        // PUT: api/Messages
        [HttpPut]

        public JsonResult Put(MessagesModel msg)
        {
            string messagesQuery = @"
                UPDATE messages
                SET username = @username, message = @message, date_time = now()
                WHERE id = @id
            ";
            DataTable table = new DataTable();
            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
            NpgsqlDataReader messageReader;
            using (NpgsqlConnection messageConnection = new NpgsqlConnection(DBConnectionString))
            {
                messageConnection.Open();
                using (NpgsqlCommand messageCommand = new(messagesQuery, messageConnection))
                {
                    
                    messageCommand.Parameters.AddWithValue("@username", value: msg.Username);
                    messageCommand.Parameters.AddWithValue("@message", value: msg.Message);
                    messageCommand.Parameters.AddWithValue("@id", value: msg.Id);
                    messageCommand.Parameters.AddWithValue("@date_time", value: msg.Date_time);
                    messageReader = messageCommand.ExecuteReader();
                    table.Load(messageReader);
                    
                    messageReader.Close();
                    messageConnection.Close();
                }
            }
            return new JsonResult("Entry updated successfully!");
        }
    }
}
            
     


      
