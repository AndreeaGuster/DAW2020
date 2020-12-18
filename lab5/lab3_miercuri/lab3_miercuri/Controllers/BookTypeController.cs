using lab3_miercuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab3_miercuri.Models.MyDatabaseInitializer;

namespace lab3_miercuri.Controllers
{
    public class BookTypeController : Controller
    {
        private DbCtx db = new DbCtx();

        public ActionResult Index()
        {
            ViewBag.BookTypes = db.BookTypes.ToList();
            return View();
        }

        public ActionResult New()
        {
            BookType bookType = new BookType();
            return View(bookType);
        }

        [HttpPost]
        public ActionResult New(BookType bookTypeRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BookTypes.Add(bookTypeRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookTypeRequest);
            }
            catch (Exception e)
            {
                return View(bookTypeRequest);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                BookType bookType = db.BookTypes.Find(id);

                if (bookType == null)
                {
                    return HttpNotFound("Couldn't find the book type with id " + id.ToString() + "!");
                }
                return View(bookType);
            }
            return HttpNotFound("Couldn't find the book type with id " + id.ToString() + "!");
        }

        [HttpPut]
        public ActionResult Edit(int id, BookType bookTypeRequestor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookType bookType = db.BookTypes.Find(id);
                    if (TryUpdateModel(bookType))
                    {
                        bookType.Name = bookTypeRequestor.Name;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(bookTypeRequestor);
            }
            catch(Exception e)
            {
                return View(bookTypeRequestor);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                BookType bookType = db.BookTypes.Find(id);
                if(bookType != null)
                {
                    db.BookTypes.Remove(bookType);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the book type with id " + id.ToString() + "!");
            }
            return HttpNotFound("Book type id parameter is missing!");
        }
    }
}