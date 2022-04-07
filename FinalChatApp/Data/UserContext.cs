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
		public virtual DbSet<MessagesModel> Messages { set; get; }

		
		//Allowing for the Username to be unique upon registry
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<UserRegisterAndLogin>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
        }
	}
}

