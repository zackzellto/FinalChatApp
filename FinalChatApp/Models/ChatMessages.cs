using System;
namespace ReactChatApp.Models
{
    public class ChatMessages
    {
        public virtual long user_id { get; set; }
        public virtual int message_id { get; set; }
        public virtual string message { get; set; }

        public ChatMessages(long user_id, int message_id, string message)
        {
            this.user_id = user_id;
            this.message_id = message_id;
            this.message = message;
        }

        public ChatMessages()
        {

        }
    }
}
