using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatAppDbContext _chatAppDbContext;

        public UserRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }

        public UserRegisterAndLogin Create(UserRegisterAndLogin user)
        {
            _chatAppDbContext.Users.Add(user);
            user.Id =_chatAppDbContext.SaveChanges();

            return user;
        }

        public UserRegisterAndLogin GetById(int id)
        {
            return _chatAppDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserRegisterAndLogin GetByLogin(string loginUser)
        {
            return _chatAppDbContext.Users.FirstOrDefault(u => u.Username == loginUser);
            
        }

        
    }
}

 