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
    }
}
