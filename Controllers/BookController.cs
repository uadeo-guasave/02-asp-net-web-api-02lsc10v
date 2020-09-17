using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using _02_asp_net_web_api_02lsc10v.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_asp_net_web_api_02lsc10v.Controllers
{
  [ApiController]
  [Route("api/books")]
  public class BookController : ControllerBase
  {
    private readonly AmazonDbContext _db;

    public BookController(AmazonDbContext db)
    {
      _db = db;
    }

    // API RESTful
    // CRUD=SQL=HTTP_METHOD
    // Create=Insert=POST Read=Select=GET Update=Update=PUT Delete=Delete=DELETE

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
    {
      var books = await _db.Books.Take(10).ToListAsync();

      if (books == null)
      {
        return NotFound();
      }

      return books;
    }

    // api/books/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
      var book = await _db.Books.FindAsync(id);
      if (book == null)
      {
        return NotFound();
      }
      return book;
    }
  }
}