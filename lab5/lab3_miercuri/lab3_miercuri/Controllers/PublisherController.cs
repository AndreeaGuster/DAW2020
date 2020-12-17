using lab3_miercuri.Models;
using lab3_miercuri.Models.MyDatabaseInitializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3_miercuri.Controllers
{
    public class PublisherController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Publisher
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Publisher publisher = new Publisher();
            return View(publisher);
        }

        [HttpPost]
        public ActionResult New(Publisher publisherRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Publishers.Add(publisherRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }
                return View(publisherRequest);
            }
            catch (Exception e)
            {
                return View(publisherRequest);
            }
        }
    }
}