using System;
using FinalChatApp.Models;

namespace FinalChatApp.Data
{
	public interface IMessageRepository
	{
		MessagesModel Create(MessagesModel message);
	}
}

