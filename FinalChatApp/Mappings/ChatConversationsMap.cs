using FluentNHibernate.Mapping;
using FinalChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalChatApp.Mappings
{
    class ChatConversationsMap : ClassMap<ChatConversations>
    {
        public ChatConversationsMap()
        {
            Id(x => x.Conversation_id);
            Map(x => x.Created_at);
            Map(x => x.Conversation_users);
            Table("conversations");
        }
    }
}