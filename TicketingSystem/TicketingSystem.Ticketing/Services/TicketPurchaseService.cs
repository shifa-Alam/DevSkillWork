using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketingSystem.Ticketing.Exceptions;
using TicketingSystem.Ticketing.UnitOfWorks;

using TicketPurchaseEntity = TicketingSystem.Ticketing.Entities.TicketPurchase;

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
            var purchasedTicketCount = _ticketingUnitOfWork.TicketPurchases.GetCount(t => t.BusNumber == ticketPurchase.BusNumber && t.SeatNumber == ticketPurchase.SeatNumber && t.OnboardingTime == ticketPurchase.OnboardingTime);
            if (purchasedTicketCount == 0)
            {
                var entity = _mapper.Map<TicketPurchaseEntity>(ticketPurchase);
                _ticketingUnitOfWork.TicketPurchases.Add(entity);
                _ticketingUnitOfWork.Save();
            }
            else throw new DuplicateException("This ticket not available");


        }

        public void Update(TicketPurchase obj)
        {

            var purchasedTicketCount = _ticketingUnitOfWork.TicketPurchases.GetCount(t => t.BusNumber == obj.BusNumber && t.SeatNumber == obj.SeatNumber
            && t.OnboardingTime == obj.OnboardingTime && t.Id != obj.Id);
            if (purchasedTicketCount == 0)
            {
                var ticketPurchaseEntity = _ticketingUnitOfWork.TicketPurchases.GetById(obj.Id);

                ticketPurchaseEntity = _mapper.Map(obj, ticketPurchaseEntity);
                //_ticketingUnitOfWork.TicketPurchaseRepo.Edit(ticketPurchaseEntity);
                _ticketingUnitOfWork.Save();
            }
            else throw new DuplicateException("This ticket not available");

        }
        public void Delete(int id)
        {
            _ticketingUnitOfWork.TicketPurchases.Remove(id);
            _ticketingUnitOfWork.Save();
        }
        public TicketPurchase GetById(int id)
        {
            var existingEntity = _ticketingUnitOfWork.TicketPurchases.GetById(id);

            return _mapper.Map<TicketPurchase>(existingEntity);

        }

        public (int total, int totalDisplay, IList<TicketPurchase> records) GetPurchaseTickets(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ticketingUnitOfWork.TicketPurchases.GetDynamic(x => x.CustomerName.Contains(searchText),
               orderBy, string.Empty, pageIndex, pageSize, true);

          var ticketPurchases = _mapper.Map<List<TicketPurchaseEntity>, List<TicketPurchase>>(result.data.ToList());


            return (result.total, result.totalDisplay, ticketPurchases);
        }

        public IList<TicketPurchase> GetPurchaseTickets()
        {
            var entities = _ticketingUnitOfWork.TicketPurchases.GetAll();

            return _mapper.Map<List<TicketPurchaseEntity>, List<TicketPurchase>>(entities.ToList());

        }


    }
}
