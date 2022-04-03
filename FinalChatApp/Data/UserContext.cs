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

		public DbSet<UserRegisterAndLogin> Users { set; get; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<UserRegisterAndLogin>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
        }
	}
}

