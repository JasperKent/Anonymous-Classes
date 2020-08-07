using System.Linq;
using AnonymousClasses.DataAccess;
using AnonymousClasses.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousClasses.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Books.Select(b => new BookModel { Id = b.Id, Title = b.Title, Author = b.Author, Publisher = b.Publisher });

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var entity = _context.Books.Single(b => b.Id == id);

            //   var model = new BookModel { Id = entity.Id, Title = entity.Title, Publisher = entity.Publisher, Author = entity.Author };

            var model = new { entity.Id, entity.Title, entity.Blurb };

            return View(model);
        }

        public IActionResult Edit (int id)
        {
            var entity = _context.Books.Single(b => b.Id == id);
            
            var model = new BookModel { Id = entity.Id, Title = entity.Title, Publisher = entity.Publisher, Author = entity.Author };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, BookModel model)
        {
            var entity = _context.Books.Single(b => b.Id == id);

            entity.Publisher = model.Publisher;
            entity.Title = model.Title;
            entity.Author = model.Author;

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }
    }
}
