using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketingSystem.Ticketing.Services;

namespace TicketingSystem.Web.Models
{
    public class TicketPurchaseModel
    {
        private ITicketPurchaseService _ticketPurchaseService;
        private ILifetimeScope _scope;
        private IMapper _mapper;


        [StringLength(100, ErrorMessage = "Customer Name should be less than 30 chars")]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string SeatNumber { get; set; }
        public int TicketPrice { get; set; }
        public string BusNumber { get; set; }
        public DateTime OnboardingTime { get; set; }= DateTime.Now;


        public TicketPurchaseModel()
        {

        }

        public TicketPurchaseModel(IMapper mapper, ITicketPurchaseService ticketPurchaseService)
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

        internal void Purchase()
        {
            var ticketPurchase = _mapper.Map<TicketPurchase>(this);

            _ticketPurchaseService.Save(ticketPurchase);
        }
    }
}
