using System;
namespace FinalChatApp.Models
{
    public class MessagesModel
    {
        public virtual string? username { get; set; }
        public virtual long? message_id { get; set; }
        public virtual string? message { get; set; }
        public virtual DateTime date_time { get; set; }

    }
}
