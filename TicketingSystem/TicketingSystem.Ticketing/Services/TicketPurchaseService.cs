using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketingSystem.Ticketing.UnitOfWorks;

namespace TicketingSystem.Ticketing.Services
{
    public class TicketPurchaseService : ITicketPurchaseService
    {
        private readonly ITicketingUnitOfWork _ticketingUnitOfWork;

        private readonly IMapper _mapper;

        public TicketPurchaseService(ITicketingUnitOfWork ticketingUnitOfWork, IMapper mapper)
        {
            _ticketingUnitOfWork = ticketingUnitOfWork;
            _mapper = mapper;
        }


        public void Save(TicketPurchase ticketPurchase)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketPurchase ticketPurchase)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public TicketPurchase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public (int total, int totalDisplay, IList<TicketPurchase> records) GetPurchaseTickets(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IList<TicketPurchase> GetPurchaseTickets()
        {
            throw new NotImplementedException();
        }


    }
}
