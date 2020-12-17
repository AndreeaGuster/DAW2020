using lab3_miercuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab3_miercuri.Models.MyDatabaseInitializer;

namespace lab3_miercuri.Controllers
{
    public class BookController : Controller
    {
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            ViewBag.Books = books;
            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Book book = db.Books.Find(id);
                if (book != null)
                {
                    return View(book);
                }
                return HttpNotFound("Couldn't find the book with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing book id parameter!");
        }

        [HttpGet]
        public ActionResult New()
        {
            Book book = new Book();
            book.BookTypeList = GetAllBookTypes();
            book.PublisherList = GetAllPublishers();

            var genres = db.Genres.ToList();
            var checkBoxListItems = new List<Genre>();

            foreach (var genre in genres)
            {
                checkBoxListItems.Add(new Genre()
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name,
                    isActive = false
                });
            }
            book.GenreCheckBoxList = checkBoxListItems;
            book.Genres = checkBoxListItems;
            return View(book);
        }

        public static void AddGenre(Book bookRequest, List<int> genres)
        {
            using (DbCtx ctx = new DbCtx())
            {
                var newBook = new Book()
                {
                    Title = bookRequest.Title,
                    Author = bookRequest.Author,
                    NoOfPages = bookRequest.NoOfPages,
                    Summary = bookRequest.Summary,
                    Publisher = bookRequest.Publisher,
                    PublisherId = bookRequest.PublisherId,
                    BookType = bookRequest.BookType,
                    BookTypeId = bookRequest.BookTypeId
                };
                foreach (var genreId in genres)
                {
                    var newGenre = ctx.Genres.Find(genreId);
                    newBook.Genres.Add(newGenre);
                    newBook.GenreCheckBoxList.Add(newGenre);
                }

                ctx.Books.Add(newBook);
                ctx.SaveChanges();
            }

        }

        [HttpPost]
        public ActionResult New(Book bookRequest)
        {
            bookRequest.BookTypeList = GetAllBookTypes();
            bookRequest.PublisherList = GetAllPublishers();

            var selectedGenres = bookRequest.GenreCheckBoxList.Where(x => x.isActive)
                .Select(x => x.GenreId).ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    AddGenre(bookRequest, selectedGenres);
                    return RedirectToAction("Index");
                }
                return View(bookRequest);
            }
            catch (Exception e)
            {
                return View(bookRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Book book = db.Books.Find(id);
                book.BookTypeList = GetAllBookTypes();
                book.PublisherList = GetAllPublishers();

                if (book == null)
                {
                    return HttpNotFound("Coludn't find the book with id " + id.ToString() + "!");
                }
                return View(book);
            }
            return HttpNotFound("Missing book id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Book bookRequest)
        {
            bookRequest.BookTypeList = GetAllBookTypes();
            bookRequest.PublisherList = GetAllPublishers();

            try
            {
                if (ModelState.IsValid)
                {
                    Book book = db.Books.Include("Publisher").Include("BookType")
                        .SingleOrDefault(b => b.BookId.Equals(id));

                    if (TryUpdateModel(book))
                    {
                        book.Title = bookRequest.Title;
                        book.Author = bookRequest.Author;
                        book.Summary = bookRequest.Summary;
                        book.NoOfPages = bookRequest.NoOfPages;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(bookRequest);
            }
            catch (Exception)
            {
                return View(bookRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the book with id " + id.ToString() + "!");
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllBookTypes()
        {
            var selectList = new List<SelectListItem>();
            foreach (var cover in db.BookTypes.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = cover.BookTypeId.ToString(),
                    Text = cover.Name
                });
            }
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllPublishers()
        {
            var selectList = new List<SelectListItem>();
            foreach (var publisher in db.Publishers.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = publisher.PublisherId.ToString(),
                    Text = publisher.Name
                });
            }
            return selectList;
        }
    }
}