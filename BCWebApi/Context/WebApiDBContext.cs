using System;
using BCWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BCWebApi.Context
{
    //Web Api Context
    public class WebApiDBContext: DbContext
    {
        public WebApiDBContext()
        {
        }

        public WebApiDBContext(DbContextOptions<WebApiDBContext> options)
        : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PriceUpdatedLog> PriceUpdatedLogs { get; set; }
        public DbSet<ProductsLog> ProductsLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserType>().HasData(
				new UserType() { UserTypeId = 1, UserTypeName = "Admin" },
				new UserType() { UserTypeId = 2, UserTypeName = "Customer" }
			);
			modelBuilder.Entity<User>().HasData(
				new User() { UserId = 1, UserTypeId = 1, UserName = "Admin", UserPassword = "root" },
				new User() { UserId = 2, UserTypeId = 2, UserName = "Armando", UserPassword = "root" }
			);
		}
	}
}
