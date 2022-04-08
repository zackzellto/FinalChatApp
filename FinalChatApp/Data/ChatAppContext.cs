using System;
using FinalChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalChatApp.Data
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

		public virtual DbSet<UserRegisterAndLogin> Users { set; get; }
		

		
		//Allowing for the Username to be unique upon registry
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<UserRegisterAndLogin>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
        }
	}

	public class MessagesContext : DbContext
	{
		public MessagesContext(DbContextOptions<MessagesContext> options) : base(options)
		{

		}

		public virtual DbSet<MessagesModel> Messages { set; get; }



		//Allowing for the Username to be unique upon registry
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MessagesModel>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
		}
	}
}

