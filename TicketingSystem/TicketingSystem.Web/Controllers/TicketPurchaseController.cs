using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Ticketing.Exceptions;
using TicketingSystem.Web.Models;

namespace TicketingSystem.Web.Controllers
{
    public class TicketPurchaseController : Controller
    {
        private  ILifetimeScope _scope;
        private  ILogger<TicketPurchaseController> _logger;
      

        public TicketPurchaseController(ILogger<TicketPurchaseController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetPurchaseTickets()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<TicketPurchaseListModel>();
            //var model = new TicketPurchaseListModel();
            return Json(model.GetPagedPurchaseTickets(dataTableModel));
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<TicketPurchaseModel>();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Create(TicketPurchaseModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    model.Purchase();

                    TempData["ResponseMessage"] = "Successfuly added a new course.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in creating course.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _scope.Resolve<PuchaseTicketEditModel>();
            model.LoadData(id);

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(PuchaseTicketEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    model.EditTicketPurchasae();

                    TempData["ResponseMessage"] = "Successfuly updated course.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["ResponseMessage"] = ioe.Message;
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in updating course.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _scope.Resolve<TicketPurchaseListModel>();
                model.DeletePurchaseTicket(id);

                TempData["ResponseMessage"] = "Successfuly deleted course.";
                TempData["ResponseType"] = ResponseTypes.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["ResponseMessage"] = "There was a problem in deleteing course.";
                TempData["ResponseType"] = ResponseTypes.Danger;
            }

            return RedirectToAction("Index");
        }
    }
}

