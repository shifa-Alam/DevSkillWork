using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.BusinessObjects;

namespace TicketingSystem.Ticketing.Services
{
    public interface ITicketPurchaseService
    {

        void Save(TicketPurchase ticketPurchase);
        void Delete(int id);
        void Update(TicketPurchase ticketPurchase);
        TicketPurchase GetById(int id);
        (int total, int totalDisplay, IList<TicketPurchase> records) GetPurchaseTickets(int pageIndex,
            int pageSize, string searchText, string orderBy);
        IList<TicketPurchase> GetPurchaseTickets();
    }
}
