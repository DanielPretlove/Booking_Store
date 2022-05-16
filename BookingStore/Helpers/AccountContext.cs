using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingStore.Helpers
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    
        private readonly IConfiguration Configuration;

        public AccountContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("BookingStore"));
        }  
    }
}