using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
	public interface IUserRepository
	{
        User Create(User user);
    }
}

