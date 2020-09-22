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
    // METODO	RUTA	PARAMETROS	RESPUESTA
    // GET	/api/books	-	Arreglo de objetos de libros
    // GET	/api/books/{id}	-	Objeto de libro
    // POST	/api/books	Objeto tipo libro	Objeto de libro ya guardado
    // PUT	/api/books/{id}	Objeto tipo libro	-
    // DELETE	/api/books/{id}	-	-


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

    [HttpPost]
    public async Task<ActionResult<Book>> SaveNewBook(Book newBook)
    {
      _db.Books.Add(newBook);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> SaveChanges(int id, Book book)
    {
      if (id != book.Id)
      {
        return BadRequest();
      }

      _db.Books.Find(id).CategoryId = book.CategoryId;

      try {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        // el libro existe
        // viole alguna restricción de la base
      }
    }
  }
}