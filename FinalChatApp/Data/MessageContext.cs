using System;
using FinalChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalChatApp.Data
{
	public class MessageContext : DbContext
    {
			public MessageContext(DbContextOptions<MessageContext> options) : base(options)
			{

			}

			public DbSet<MessagesModel> Messages { set; get; }


			//Allowing for the Username to be unique upon registry
			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<MessagesModel>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
			}
		
	}
}

