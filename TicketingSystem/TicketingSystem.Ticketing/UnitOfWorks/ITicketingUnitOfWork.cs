using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Ticketing.Repositories;

namespace TicketingSystem.Ticketing.UnitOfWorks
{
    public interface ITicketingUnitOfWork : IUnitOfWork
    {
        ITicketPurchaseRepository TicketPurchaseRepo { get; }
    }
}
