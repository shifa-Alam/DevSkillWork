using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Ticketing.DbContexts;
using TicketingSystem.Ticketing.Repositories;

namespace TicketingSystem.Ticketing.UnitOfWorks
{
    internal class TicketingUnitOfWork : UnitOfWork, ITicketingUnitOfWork
    {
        public ITicketPurchaseRepository TicketPurchases { get; private set; }

 
        public TicketingUnitOfWork(ITicketingDbContext dbContext,
           ITicketPurchaseRepository TicketPurchaseRepository) : base((DbContext)dbContext)
        {
            TicketPurchases = TicketPurchaseRepository;
           
        }

    }
}
