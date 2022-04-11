using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatAppDbContext _chatAppDbContext;

        public MessageRepository(ChatAppDbContext chatAppDbContext)
        {
            _chatAppDbContext = chatAppDbContext;
        }

        public MessagesModel Create(MessagesModel message)
        {
            _chatAppDbContext.Messages.Add(message);
            message.Id = _chatAppDbContext.SaveChanges();

            return message;
        }
    }
}

