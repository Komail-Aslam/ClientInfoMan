using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class PictureController : Controller
    {
        Models.ClientInformationEntities db = new Models.ClientInformationEntities();
        // GET: Picture
        public ActionResult Index(int id)
        {
            ViewBag.id = id;

            var thePicture = db.PersonInformations.SingleOrDefault(c => c.person_id == id);
            return View(thePicture);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            Models.Picture thePicture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(thePicture);
        }

        // GET: Picture/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            Models.PersonInformation thePerson = db.PersonInformations.SingleOrDefault(p => p.person_id == id);
            return View();
        }

        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection, HttpPostedFileBase newPicture)
        {
            try
            {
                var type = newPicture.ContentType;
                string[] acceptableTypes = { "image/jpeg", "image/gif", "image/png" };
                if (newPicture != null && newPicture.ContentLength > 0 && acceptableTypes.Contains(type))
                {
                    Guid g = Guid.NewGuid();
                    string filename = g.ToString() + Path.GetExtension(newPicture.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/") + filename);
                    newPicture.SaveAs(path);
                    Models.Picture newPic = new Models.Picture()
                    {
                        caption = collection["Caption"],
                        path_of_picture = filename,
                        location_info = collection["Location"],
                        person_id = id,
                        time_info = collection["Time"]
                    };
                    db.Pictures.Add(newPic);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Picture thePicture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(thePicture);
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Picture thePicture = db.Pictures.SingleOrDefault(p => p.picture_id == id);

                db.Pictures.Remove(thePicture);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = thePicture.person_id });
            
            }
            catch
            {
                return View();
            }
        }
    }
}
