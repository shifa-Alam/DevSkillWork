using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.Entities;

namespace TicketingSystem.Ticketing.DbContexts
{
    internal class TicketingDbContext : DbContext, ITicketingDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public TicketingDbContext(string connectionString, string assemblyName)
        {
            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<TicketPurchase> TicketPurchases { get; set; }
    }
}
