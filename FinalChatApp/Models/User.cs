﻿using System;
namespace FinalChatApp.Models
{
	public class User
	{
		public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		//public byte[]? PasswordHash { get; set; }

		//public byte[]? PasswordSalt { get; set; }
	}
}

