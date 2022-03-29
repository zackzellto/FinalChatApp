using System;
namespace FinalChatApp.Models
{
    public class MessagesModel
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime Date_time { get; set; }

    }
}
