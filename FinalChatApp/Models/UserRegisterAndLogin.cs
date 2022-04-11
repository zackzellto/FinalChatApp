using System;
using Newtonsoft.Json;

namespace FinalChatApp.Models
{
	public class UserRegisterAndLogin
    {
		public int Id { get; set; }
        public string? Username { get; set; } 
        [JsonIgnore] public string? Password { get; set; }

    }
}

