using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class HomeController : Controller
    {
        Models.ClientInformationEntities db = new Models.ClientInformationEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.PersonInformations);
        }

        public ActionResult Search(string name)
        {
            var results = db.PersonInformations.Where(p => (p.first_name + p.last_name).Contains(name));
            return View(results);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.PersonInformation thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);
            return View(thePerson);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.PersonInformation newPerson = new Models.PersonInformation();
                newPerson.first_name = collection["first_name"];
                newPerson.last_name = collection["last_name"];
                newPerson.notes = collection["notes"];
                newPerson.gender = collection["gender"];
                newPerson.profile_picture = 0;

                db.PersonInformations.Add(newPerson);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);
            return View(thePerson);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Models.PersonInformation thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);
                thePerson.first_name = collection["first_name"];
                thePerson.last_name = collection["last_name"];
                thePerson.notes = collection["notes"];
                thePerson.gender = collection["gender"];
                thePerson.profile_picture = 0;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Models.PersonInformation thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);
            return View(thePerson);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.PersonInformation thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);

                db.Addresses.RemoveRange(thePerson.Addresses);
                db.Pictures.RemoveRange(thePerson.Pictures);
                thePerson.profile_picture = null;
                db.ContactInformations.RemoveRange(thePerson.ContactInformations);
                db.SaveChanges();

                db.PersonInformations.Remove(thePerson);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}