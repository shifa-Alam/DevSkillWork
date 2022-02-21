using AutoMapper;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketingSystem.Web.Models;

namespace TicketingSystem.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TicketPurchaseModel, TicketPurchase>()
                .ReverseMap();

            CreateMap<PuchaseTicketEditModel, TicketPurchase>()
                .ReverseMap();
        }
    }
}
