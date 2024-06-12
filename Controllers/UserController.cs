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
    
    private readonly ILogger<TaskController> _logger; //used for protocols

    public UserController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    //HTTP Get TaskController: gives him the user he wants, when it gets a id
    //HTTP Post: I get data, and shall create a new user out of that

    [HttpGet]
    public IActionResult Get(int id)
    {
        try
        {
            GetUser user = new GetUser();
            user.GetUserFromInput(id);
            return Ok("works"); //just gives back, that it works
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while getting the user."); //just an errormessage
        }
    }

    [HttpPost]
    public IActionResult Post(string username, string email, int points, string utype, string lastlogin, string lastLogout, string birthdate, string password, int group)
    {
        try
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            int maxId = context.Users.Max(u => (int?)u.id) ?? 0; //here we search the max id of the user, int nullable, and the standard valuable is zero.
            Models.User user = new Models.User(username, email, points, utype, lastlogin, lastLogout, birthdate, password, group); //creating user
            user.id = maxId + 1; //other way, than auto_increment
            context.Users.Add(user);
            context.SaveChanges();
            return Ok("works");
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the user."); //just an errormessage
        }
    }    
}