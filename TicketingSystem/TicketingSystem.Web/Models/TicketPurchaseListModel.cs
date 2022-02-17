using Autofac;
using AutoMapper;
using TicketingSystem.Ticketing.Services;

namespace TicketingSystem.Web.Models
{
    public class TicketPurchaseListModel
    {
        private  ITicketPurchaseService _ticketPurchasaeService;
        private ILifetimeScope _scope;
        private IMapper _mapper;

        public TicketPurchaseListModel()
        {

        }
        public TicketPurchaseListModel(ITicketPurchaseService ticketPurchaseService,ILifetimeScope scope,IMapper mapper)
        {
            _ticketPurchasaeService = ticketPurchaseService;
            _scope = scope;
            _mapper = mapper;
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string SeatNumber { get; set; }
        public int TicketPrice { get; set; }
        public string BusNumber { get; set; }
        public DateTime OnboardingTime { get; set; }



        public object GetPagedPurchaseTickets(DataTablesAjaxRequestModel model)
        {
            var data =_ticketPurchasaeService.GetPurchaseTickets(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "CustomerName", "TicketPrice" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.CustomerName,
                                record.TicketPrice.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeletePurchaseTicket(int id)
        {
           _ticketPurchasaeService.Delete(id);
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _ticketPurchasaeService = _scope.Resolve<ITicketPurchaseService>();
            _mapper = _scope.Resolve<IMapper>();
        }
    }
}
