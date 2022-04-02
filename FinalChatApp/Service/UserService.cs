//using System;
//using FinalChatApp.Common;
//using FinalChatApp.IService;
//using FinalChatApp.Models;

//namespace FinalChatApp.Service
//{
//    public class UserService : IUserService
//    {
//        public List<UserRegisterAndLogin> IUserService.GetAllUsers()
//        {
//            return Global.Users;
//        }

//        public List<User> GetAllUsers()
//        {
//            throw new NotImplementedException();
//        }

//        public UserRegisterAndLogin IUserService.Login(UserRegisterAndLogin oUser)
//        {
//            var user = Global.Users.SingleOrDefault(x => x.Username == oUser.Username);
//            bool isValidPassword = BCrypt.Net.BCrypt.Verify(oUser.Password, user.Password);

//            if(isValidPassword)
//            {
//                return user;
//            }
//            return null;
//        }

//        public User Login(User oUser)
//        {
//            throw new NotImplementedException();
//        }

//        public UserRegisterAndLogin IUserService.Signup(UserRegisterAndLogin oUser)
//        {
//            oUser.Password = BCrypt.Net.BCrypt.HashPassword(oUser.Password);
//            Global.Users.Add(oUser);
//            return oUser;
//        }

//        public User Signup(User oUser)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

