using MVC.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC.Contacts.Controllers
{
    public class HomeController : Controller
    { 
        
        IContactsDb _db;

        public HomeController()
        {
            _db = new ContactsDb();
        }

        public HomeController(IContactsDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Query<Contact>()
                   .Where(r => r.Name.StartsWith(term))
                   .Take(10)
                   .Select(r => new
                   {
                       label = r.Name
                   });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Contacts
        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            var model = _db.Query<Contact>()
                   .OrderBy(r => r.Name)
                   .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                   .Select(r => new ContactListViewModel
                   {
                       ContactId = r.ContactId,
                       Name = r.Name,
                       Address = r.Address,
                       City = r.City,
                       Email = r.Email,
                       State = r.State,
                       Twitter = r.Twitter,
                       Zip = r.Zip

                   }).ToPagedList(page, 10);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_ContactList", model);
            }

            return View(model);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}