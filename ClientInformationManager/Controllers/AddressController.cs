using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class AddressController : Controller
    {
        Models.ClientInformationEntities db = new Models.ClientInformationEntities();
        // GET: Address
        public ActionResult Index(int id)
        {
            ViewBag.id = id;

            var theAddresses = db.PersonInformations.SingleOrDefault(c => c.person_id == id);
            return View(theAddresses);
        }

            // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            Models.Address theAddress = db.Addresses.SingleOrDefault(a => a.address_id == id);
            return View(theAddress);
        }

        // GET: Address/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;

            IEnumerable<SelectListItem> countries = db.Countries.Select(c => new SelectListItem()
            {
                Value = c.country_id.ToString(),
                Text = c.country_name
            });
            ViewBag.countries = countries;

            Models.PersonInformation person = db.PersonInformations.SingleOrDefault(c => c.person_id == id);
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
          
            try
            {
                // TODO: Add insert logic here
                Models.Address address = new Models.Address()
                {
                    person_id = id,
                    description = collection["description"],
                    street_address = collection["street_address"],
                    city = collection["city"],
                    province_state = collection["province_state"],
                    zip_postal_code = collection["zip_postal_code"],
                    country_id = Int32.Parse(collection["country_id"])

                };

                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> countries = db.Countries.Select(c => new SelectListItem()
            {
                Value = c.country_id.ToString(),
                Text = c.country_name
            });
            ViewBag.countries = countries;


            Models.Address theAddress = db.Addresses.SingleOrDefault(a => a.address_id == id);
            return View(theAddress);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Address theAddress = db.Addresses.SingleOrDefault(a => a.address_id == id);
                theAddress.city = collection["city"];
                theAddress.street_address = collection["street_address"];
                theAddress.description = collection["description"];
                theAddress.province_state = collection["province_state"];
                theAddress.zip_postal_code = collection["zip_postal_code"];
                theAddress.country_id = Int32.Parse(collection["country_id"]);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = theAddress.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Address theAddress = db.Addresses.SingleOrDefault(p => p.address_id == id);
            return View(theAddress);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Address theAddress = db.Addresses.SingleOrDefault(p => p.address_id == id);
                db.Addresses.Remove(theAddress);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = theAddress.person_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
