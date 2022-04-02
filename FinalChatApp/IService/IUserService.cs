using System;
using FinalChatApp.Models;

namespace FinalChatApp.IService
{
	public interface IUserService
	{

		User Signup(User oUser);

		User Login(User oUser);

        List<User> GetAllUsers();
		
	}
}

