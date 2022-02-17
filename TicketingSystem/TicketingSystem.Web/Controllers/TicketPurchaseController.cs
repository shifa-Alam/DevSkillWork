using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Web.Controllers
{
    public class TicketPurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
