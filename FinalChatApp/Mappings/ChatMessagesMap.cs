using FinalChatApp.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalChatApp.Mappings
{
    class ChatMessagesMap : ClassMap<ChatMessages>
    {
        public ChatMessagesMap()
        {
            Id(x => x.user_id);
            Id(x => x.message_id);
            Map(x => x.message);
            Table("messages");
        }
    }
}