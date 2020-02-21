using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class ContactController : Controller
    {
        Models.ClientInformationEntities db = new Models.ClientInformationEntities();
        // GET: Contact
        public ActionResult Index(int id)
        {
            ViewBag.id = id;

            var theContacts = db.PersonInformations.SingleOrDefault(c => c.person_id == id);
            return View(theContacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            Models.ContactInformation theContact = db.ContactInformations.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // GET: Contact/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            Models.PersonInformation person = db.PersonInformations.SingleOrDefault(c => c.person_id == id);
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.ContactInformation newContact = new Models.ContactInformation()
                {
                    person_id = id,
                    type_of_info = collection["type_of_info"],
                    info = collection["info"]
                };

                db.ContactInformations.Add(newContact);
                db.SaveChanges();
                return RedirectToAction("Index", new { id =id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            Models.ContactInformation theContact = db.ContactInformations.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.ContactInformation theContact = db.ContactInformations.SingleOrDefault(c => c.contact_id == id);

                theContact.type_of_info = collection["type_of_info"];
                theContact.info = collection["info"];

                db.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Models.ContactInformation theContact = db.ContactInformations.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.ContactInformation theContact = db.ContactInformations.SingleOrDefault(c => c.contact_id == id);

                db.ContactInformations.Remove(theContact);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.person_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
