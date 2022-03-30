using System;
namespace FinalChatApp.Models
{
	public class UserRegisterAndLogin
	{
		public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
	}
}

