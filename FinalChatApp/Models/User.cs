using System;
using Newtonsoft.Json;

namespace FinalChatApp.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Username { get; set; } = string.Empty;

		[JsonIgnore] public string Password { get; set; } = string.Empty;

		//public byte[]? PasswordHash { get; set; }

		//public byte[]? PasswordSalt { get; set; }
	}
}

