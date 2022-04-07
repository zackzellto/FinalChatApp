
namespace FinalChatApp.Models
{
    public class MessagesModel
    {
        public virtual int Id { get; set; }
        public virtual string? Username { get; set; } = string.Empty;
        public virtual string? Message { get; set; } = string.Empty;
        public virtual DateTime Date_time { get; set; }

    }
}
