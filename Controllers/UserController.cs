using System.Collections.Generic;
using System.Linq;
using _02_asp_net_web_api_02lsc10v.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_asp_net_web_api_02lsc10v.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {
    private readonly AmazonDbContext _db;
    public UserController(AmazonDbContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
      // select * from users limit 10;
      var users = _db.Users.Take(10).ToArray();
      if (users.Length == 0)
      {
        return NotFound();
      }

      return users;
    }
  }
}