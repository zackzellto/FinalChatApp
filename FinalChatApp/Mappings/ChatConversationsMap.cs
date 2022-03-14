using FluentNHibernate.Mapping;
using ReactChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactChatApp.Mappings
{
    class ChatConversationsMap : ClassMap<ChatConversations>
    {
        public ChatConversationsMap()
        {
            Id(x => x.conversation_id);
            Map(x => x.created_at);
            Map(x => x.conversation_users);
            Table("conversations");
        }
    }
}