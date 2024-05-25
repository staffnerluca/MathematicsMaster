using System.Data.SqlTypes;
using System.Drawing.Drawing2D;
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
    public IActionResult Post(int id, string username, string email, int points, string utype, DateTime lastlogin, DateTime lastLogout, bool darkmode, DateTime birthdate)
    {
        Models.User user = new Models.User(id, username, email, points, utype, lastlogin, lastLogout, darkmode, birthdate); 
        return Ok("funktioniert");
    }    
}