using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class CountryController : Controller
    {
        Models.ClientInformationEntities db = new Models.ClientInformationEntities();
        // GET: Country
        public ActionResult Index()
        {
            return View(db.Countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            Models.Country theCountry = db.Countries.SingleOrDefault(c => c.country_id == id);
            return View(theCountry);
        }
    }
}
