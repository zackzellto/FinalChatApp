using System;
namespace FinalChatApp.Models
{
    public class ChatConversations
    {
        public virtual long Conversation_id { get; set; }
        public virtual string Created_at{ get; set; }
        public virtual string Conversation_users { get; set; }

        public ChatConversations(long conversation_id, string created_at, string conversation_users)
        {
            this.Conversation_id = conversation_id;
            this.Created_at = created_at;
            this.Conversation_users = conversation_users;
        }

    }
}
