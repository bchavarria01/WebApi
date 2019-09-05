using System;
using BCWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BCWebApi.Context
{
    public class WebApiDBContext: DbContext
    {
        public WebApiDBContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }
    }
}
