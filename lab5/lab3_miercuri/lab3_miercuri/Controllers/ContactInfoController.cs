using lab3_miercuri.Models;
using lab3_miercuri.Models.MyDatabaseInitializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3_miercuri.Controllers
{
    public class ContactInfoController : Controller
    {
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult New()
        {
            ContactInfo contact = new ContactInfo();
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            return View(contact);
        }

        [HttpPost]
        public ActionResult New(ContactInfo contactRequest)
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactsInfo.Add(contactRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }
                return View(contactRequest);
            }
            catch (Exception e)
            {
                return View(contactRequest);
            }
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRegions()
        {
            var selectList = new List<SelectListItem>();
            foreach (var region in db.Regions.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = region.RegionId.ToString(),
                    Text = region.Name
                });
            }
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllGenderTypes()
        {
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = Gender.Male.ToString(),
                Text = "Male"
            });

            selectList.Add(new SelectListItem
            {
                Value = Gender.Female.ToString(),
                Text = "Female"
            });

            return selectList;
        }
    }
}