using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Ticketing.BusinessObjects
{
    public class TicketPurchase
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string SeatNumber { get; set; }
        public int TicketPrice { get; set; }
        public string BusNumber { get; set; }
        public DateTime OnboardingTime { get; set; }

    }
}
