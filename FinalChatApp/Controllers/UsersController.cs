//using System.Data;
//using FinalChatApp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Npgsql;
//using BCrypt;


//namespace FinalChatApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {

//        private readonly IConfiguration _configuration;
//        public UsersController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        //private readonly IUserService _userService = null;

//        //public UsersController(IUserService userService)
//        //{
//        //    _userService = userService;
//        //}


//        // GET: api/Users
//        [HttpGet]

//        public JsonResult Get()
//        {
//            string usersQuery = @"
//                SELECT id as ""Id"",
//                        username as ""Username"",
//                        password as ""Password""
//                FROM users";

//            DataTable table = new DataTable();
//            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
//            NpgsqlDataReader usersReader;
//            using (NpgsqlConnection usersConnection = new NpgsqlConnection(DBConnectionString))
//            {
//                usersConnection.Open();
//                using (NpgsqlCommand usersCommand = new(usersQuery, usersConnection))
//                {
//                    usersReader = usersCommand.ExecuteReader();
//                    table.Load(usersReader);

//                    usersReader.Close();
//                    usersConnection.Close();
//                }
//            }
//            return new JsonResult(table);
//        }

//        // POST: api/Users
//        [HttpPost]

//        public JsonResult Post(UserRegisterAndLogin usr)
//        {
//            string usersQuery = @"
//                INSERT INTO users (username, password)
//                VALUES (@username, @password)
//            ";
//            DataTable table = new DataTable();
//            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
//            NpgsqlDataReader usersReader;
//            using (NpgsqlConnection usersConnection = new NpgsqlConnection(DBConnectionString))
//            {
//                usersConnection.Open();
//                using (NpgsqlCommand usersCommand = new(usersQuery, usersConnection))
//                {
//                    usersCommand.Parameters.AddWithValue("@username", value: usr.Username);
//                    usersCommand.Parameters.AddWithValue("@password", value: usr.Password);

//                    usersReader = usersCommand.ExecuteReader();
//                    table.Load(usersReader);

//                    usersReader.Close();
//                    usersConnection.Close();
//                }
//            }
//            return new JsonResult("User Added Successfully!");
//        }

//        // PUT: api/Users
//        [HttpPut]

//        public JsonResult Put(UserRegisterAndLogin usr)
//        {
//            string usersQuery = @"
//                UPDATE users
//                SET username = @username, password = @password
//                WHERE id = @id
//            ";
//            DataTable table = new DataTable();
//            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
//            NpgsqlDataReader usersReader;
//            using (NpgsqlConnection usersConnection = new NpgsqlConnection(DBConnectionString))
//            {
//                usersConnection.Open();
//                using (NpgsqlCommand usersCommand = new(usersQuery, usersConnection))
//                {
//                    usersCommand.Parameters.AddWithValue("@id", value: usr.Id);
//                    usersCommand.Parameters.AddWithValue("@username", value: usr.Username);
//                    usersCommand.Parameters.AddWithValue("@password", value: usr.Password);
//                    usersReader = usersCommand.ExecuteReader();
//                    table.Load(usersReader);

//                    usersReader.Close();
//                    usersConnection.Close();
//                }
//            }
//            return new JsonResult("User Updated Successfully!");
//        }

//        // DELETE: api/Users
//        [HttpDelete]

//        public JsonResult Delete(int id)
//        {
//            string usersQuery = @"
//                DELETE FROM users
//                WHERE id = @id
//            ";
//            DataTable table = new DataTable();
//            string DBConnectionString = _configuration.GetConnectionString("DBConnectionString");
//            NpgsqlDataReader usersReader;
//            using (NpgsqlConnection usersConnection = new NpgsqlConnection(DBConnectionString))
//            {
//                usersConnection.Open();
//                using (NpgsqlCommand usersCommand = new(usersQuery, usersConnection))
//                {

//                    usersCommand.Parameters.AddWithValue("@id", value: id);
//                    usersReader = usersCommand.ExecuteReader();
//                    table.Load(usersReader);
//                    usersReader.Close();
//                    usersConnection.Close();
//                }
//            }
//            return new JsonResult("User Deleted Successfully!");
//        }
//    }
//}