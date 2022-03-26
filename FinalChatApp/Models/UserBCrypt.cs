using System;
namespace FinalChatApp.Models
{
	public class UserBCrypt
	{
		public virtual int Id { get; set; }

		public string Username { get; set; } = string.Empty;

		public string Password { get; set; }
	}
}

