using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Ticketing.DbContexts;
using TicketingSystem.Ticketing.Entities;

namespace TicketingSystem.Ticketing.Repositories
{
    public class TicketPurchaseRepository : Repository<TicketPurchase, int>, ITicketPurchaseRepository
    {
        public TicketPurchaseRepository(ITicketingDbContext context) : base((DbContext)context)
        {
        }

        //public TicketPurchaseRepository(DbContext context) : base(context)
        //{
        //}

       
    }
}
