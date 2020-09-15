using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using _02_asp_net_web_api_02lsc10v.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_asp_net_web_api_02lsc10v.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BookController : ControllerBase
  {
    // API RESTful
    // CRUD=SQL=HTTP_METHOD
    // Create=Insert=POST Read=Select=GET Update=Update=PUT Delete=Delete=DELETE

    [HttpGet]
    public IEnumerable<Book> Get()
    {
      using (var db = new AmazonDbContext())
      {
        try
        {
            return db.Books.Take(10).ToArray();
        //   var books = db.Books.Include(b => b.Category).Take(10).ToList();
        //   return JsonSerializer.Serialize(books);
        }
        catch (System.Exception ex)
        {
        //   StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
          throw ex;
        }
      }
    }
  }
}