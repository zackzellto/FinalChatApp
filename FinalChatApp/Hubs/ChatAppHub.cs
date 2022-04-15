using System;
using FinalChatApp.Service;
using Microsoft.AspNetCore.SignalR;

namespace FinalChatApp.Hubs
{
	public class ChatAppHub : Hub
	{

		private readonly string _chatAppBot;

		public ChatAppHub()
        {
			_chatAppBot = "ChatBot 1.0";
        }

		public async Task JoinRoom(UserConnection userConnection)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

			await Clients.Group(userConnection.Room).SendAsync
                ("ReceiveMessage", _chatAppBot, $"{userConnection.User} has joined {userConnection.Room}");
		}
    }
}

