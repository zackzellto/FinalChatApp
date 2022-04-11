using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
	public interface IUserRepository
	{
        UserRegisterAndLogin Create(UserRegisterAndLogin user);
        UserRegisterAndLogin GetByLogin(string loginUser);
        UserRegisterAndLogin GetById(int id);
    }
}

