using FinalChatApp.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalChatApp.Mappings
{
    class ChatMessagesMap : ClassMap<MessagesModel>
    {
        public ChatMessagesMap()
        {
            Id(x => x.Username);
            Map(x => x.Message);
            Map(x => x.Date_time);
            Table("messages");
        }
    }
}