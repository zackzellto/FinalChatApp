using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
	public interface IUserRepository
	{
        UserRegisterAndLogin Create(UserRegisterAndLogin user);
    }
}

