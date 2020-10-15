using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_asp_net_web_api_02lsc10v.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

    private bool NameExists(string name) =>
      _db.Users.Any(u => u.Name == name);

    private bool EmailExists(string email) =>
      _db.Users.Any(u => u.Email == email);

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

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody, BindRequired] User newUser)
    {
      TryValidateModel(newUser);

      if (NameExists(newUser.Name) || EmailExists(newUser.Email))
      {
        return UnprocessableEntity();
      }

      _db.Users.Add(newUser);
      await _db.SaveChangesAsync();

      return newUser;
    }
  }
}