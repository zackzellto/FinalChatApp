using System;
namespace ReactChatApp.Models
{
    public class ChatConversations
    {
        public virtual long conversation_id { get; set; }
        public virtual string created_at{ get; set; }
        public virtual string conversation_users { get; set; }

        public ChatConversations(long conversation_id, string created_at, string conversation_users)
        {
            this.conversation_id = conversation_id;
            this.created_at = created_at;
            this.conversation_users = conversation_users;
        }

        public ChatConversations()
        {

        }

    }
}
