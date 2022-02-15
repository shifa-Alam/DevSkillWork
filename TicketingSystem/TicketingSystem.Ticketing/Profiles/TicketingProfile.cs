using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.BusinessObjects;
using TicketPurchaseEo = TicketingSystem.Ticketing.Entities.TicketPurchase;
namespace TicketingSystem.Ticketing.Profiles
{
    public class TicketingProfile : Profile
    {
        public TicketingProfile()
        {
            CreateMap<TicketPurchaseEo, TicketPurchase>().ReverseMap();
        }
    }
}
