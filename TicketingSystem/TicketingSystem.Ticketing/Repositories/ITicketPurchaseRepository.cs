using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Ticketing.Entities;

namespace TicketingSystem.Ticketing.Repositories
{
    internal interface ITicketPurchaseRepository : IRepository<TicketPurchase, int>
    {
    }
}
