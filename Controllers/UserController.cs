using System.Data.SqlTypes;
using System.Drawing.Drawing2D;
using Google.Protobuf.WellKnownTypes;
using MathMaster.ClassesOfTheProject;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public UserController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    //HTTP Get TaskController: Soll ihm dann einen Task geben
    //HTTP Post: Bekomme Daten und soll daraus den Task erstellen

    [HttpGet]
    public IActionResult Get(int id)
    {
        GetUser user = new GetUser();
        user.GetUserFromInput(id);
        return Ok("works");
    }

    [HttpPost]
    public IActionResult Post(string username, string email, int points, string utype, string lastlogin, string lastLogout, string birthdate, string password, int group)
    {
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        int maxId = context.Users.Max(u => (int?)u.id) ?? 0;
        Models.User user = new Models.User(username, email, points, utype, lastlogin, lastLogout, birthdate, password, group);
        user.id = maxId + 1;
        context.Users.Add(user);
        context.SaveChanges();
        return Ok("funktioniert");
    }    
}