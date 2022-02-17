using Autofac;
using AutoMapper;

using System.ComponentModel.DataAnnotations;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketingSystem.Ticketing.Services;

namespace TicketingSystem.Web.Models
{
    public class PuchaseTicketEditModel
    {
        private ITicketPurchaseService _ticketPurchaseService;
        private ILifetimeScope _scope;
        private IMapper _mapper;

        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Customer Name should be less than 30 chars")]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string SeatNumber { get; set; }
        public int TicketPrice { get; set; }
        public string BusNumber { get; set; }
        public DateTime OnboardingTime { get; set; }
        public PuchaseTicketEditModel()
        {

        }

        public PuchaseTicketEditModel(IMapper mapper, ITicketPurchaseService ticketPurchaseService)
        {
            _ticketPurchaseService = ticketPurchaseService;
            _mapper = mapper;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _ticketPurchaseService = _scope.Resolve<ITicketPurchaseService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        public void EditTicketPurchasae()
        {
            var ticketPurchasae = _mapper.Map<TicketPurchase>(this);

            _ticketPurchaseService.Update(ticketPurchasae);
        }

        internal void LoadData(int id)
        {
            var ticketPurchasae = _ticketPurchaseService.GetById(id);
            _mapper.Map(ticketPurchasae, this);
        }
    }
}
