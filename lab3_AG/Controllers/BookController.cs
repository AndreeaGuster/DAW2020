using lab3_AG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3_AG.Controllers
{
    public class BookController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = db.Books.Include("Publisher").ToList();
            ViewBag.Books = books;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Book book = db.Books.Find(id);
                if(book != null)
                {
                    return View(book);
                }
                return HttpNotFound("Couldn't find the book with id " + id.ToString());
            }
            return HttpNotFound("Missing book id parameter!");
        }
    }
}