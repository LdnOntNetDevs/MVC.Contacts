using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Contacts.Models;

namespace MVC.Contacts.Controllers
{
    public class ContactPhonesController : Controller
    {
        private ContactsDb db = new ContactsDb();

        // GET: ContactPhones
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactPhones.ToListAsync());
        }

        // GET: ContactPhones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = await db.ContactPhones.FindAsync(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // GET: ContactPhones/Create
        public ActionResult Create(int ContactId)
        {
            return View();
        }

        // POST: ContactPhones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContactPhoneId,PhoneNumber,Type,ContactId")] ContactPhone contactPhone,string RedirectUrl)
        {
            if (ModelState.IsValid)
            {
                db.ContactPhones.Add(contactPhone);
                await db.SaveChangesAsync();
                return Redirect(RedirectUrl);
            }

            return View(contactPhone);
        }

        // GET: ContactPhones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = await db.ContactPhones.FindAsync(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // POST: ContactPhones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContactPhoneId,PhoneNumber,Type,ContactId")] ContactPhone contactPhone, string RedirectUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactPhone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Redirect(RedirectUrl);
            }
            return View(contactPhone);
        }

        // GET: ContactPhones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = await db.ContactPhones.FindAsync(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // POST: ContactPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id,string RedirectUrl)
        {
            ContactPhone contactPhone = await db.ContactPhones.FindAsync(id);
            db.ContactPhones.Remove(contactPhone);
            await db.SaveChangesAsync();
            return Redirect(RedirectUrl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
