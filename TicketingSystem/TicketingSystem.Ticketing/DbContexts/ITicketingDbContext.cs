using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.Entities;

namespace TicketingSystem.Ticketing.DbContexts
{
    public interface ITicketingDbContext
    {
        DbSet<TicketPurchase> TicketPurchases { get; set; }
    }
}
