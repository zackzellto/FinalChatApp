﻿using FinalChatApp.Models;
using FluentNHibernate.Mapping;
using System; 
using System.Collections.Generic; 
using System.Linq; using System.Text; 
using System.Threading.Tasks;

namespace FinalChatApp.Mappings
{
    class UserRegisterLoginMap : ClassMap<UserRegisterAndLogin>
    {
        public UserRegisterLoginMap()
        {
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Password);
            Table("users");
        }
    }
}