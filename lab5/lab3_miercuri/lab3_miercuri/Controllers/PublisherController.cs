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
        private DbCtx ctx = new DbCtx();

        // GET: Publisher
        public ActionResult Index()
        {
            ViewBag.Publishers = ctx.Publishers.ToList();
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Publisher publisher = ctx.Publishers.Find(id);
                if (publisher != null)
                {
                    ViewBag.Region = ctx.Regions.Find(publisher.ContactInfo.RegionId).Name;
                    return View(publisher);
                }
                return HttpNotFound("Couldn't find the publisher with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing publisher id parameter!");
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();

            PublisherContactViewModel pc = new PublisherContactViewModel();
            return View(pc);
        }

        [HttpPost]
        public ActionResult New(PublisherContactViewModel pcViewModel)
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            try
            {
                if (ModelState.IsValid)
                {
                    ContactInfo contact = new ContactInfo { 
                        PhoneNumber = pcViewModel.PhoneNumber,
                        CNP = pcViewModel.CNP,
                        BirthDay = pcViewModel.BirthDay,
                        BirthMonth = pcViewModel.BirthMonth,
                        BirthYear = pcViewModel.BirthYear,
                        Resident = pcViewModel.Resident,
                        RegionId = pcViewModel.RegionId
                    };
                    // vom adauga in baza de date ambele obiecte 
                    ctx.ContactsInfo.Add(contact);
                    Publisher publisher = new Publisher { 
                        Name = pcViewModel.Name,
                        ContactInfo = contact
                    };
                    ctx.Publishers.Add(publisher);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(pcViewModel);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                return View(pcViewModel);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Publisher publisher = ctx.Publishers.Find(id);
            ContactInfo contact = ctx.ContactsInfo.Find(publisher.ContactInfo.ContactInfoId);

            if (publisher != null)
            {
                ctx.Publishers.Remove(publisher);
                ctx.ContactsInfo.Remove(contact);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the publisher with id " + id.ToString() + "!");
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRegions()
        {
            var selectList = new List<SelectListItem>();
            foreach (var region in ctx.Regions.ToList())
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