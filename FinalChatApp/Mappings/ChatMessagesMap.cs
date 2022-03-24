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
            Id(x => x.username);
            Id(x => x.message_id);
            Map(x => x.message);
            Map(x => x.date_time);
            Table("messages");
        }
    }
}