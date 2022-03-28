using System;
namespace FinalChatApp.Models
{
    public class UserBCrypt
	{
		public virtual int Id { get; set; }

		public virtual string Username { get; set; } = string.Empty;

		public virtual string Password { get; set; }
    }
}

