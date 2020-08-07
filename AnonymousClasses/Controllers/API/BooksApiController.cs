using System.Collections.Generic;
using System.Linq;
using AnonymousClasses.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousClasses.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksApiController(LibraryContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<object>> Get()
        {
            var model = _context.Books.Select(b => new { Id = b.Id, Title = b.Title, Blurb = b.Blurb });

            return Ok(model);
        }
    }
}
