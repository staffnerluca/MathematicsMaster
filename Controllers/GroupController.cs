using System.Data.SqlTypes;
using MathMaster.ClassesOfTheProject;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public GroupController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    //HTTP Get TaskController: Soll ihm dann einen Task geben
    //HTTP Post: Bekomme Daten und soll daraus den Task erstellen

    [HttpGet]
    public IActionResult Get(string name)
    {
        try
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Group? returnObject = context.Groups.FirstOrDefault(x => x.name == name);
            if (returnObject != null)
            {
                return Ok(new { status = "e" }); //group does exist
            }
            else
            {
                return Ok(new { status = "ne" }); //group doesnt exist
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the user.");
        }
    }

    [HttpPost]
    public IActionResult Post()
    {
        try
        {
            string name = Request.Form["name"];
            int owner = Int32.Parse(Request.Form["userid"]);
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            int lastId = context.Groups.Max(u => (int?)u.id) ?? 0;
            Models.Group group = new Models.Group(lastId + 1, name, owner);
            Models.Group? returnObject = context.Groups.FirstOrDefault(x => x.name == name);
            if (returnObject == null)
            {
                context.Groups.Add(group);
                context.SaveChanges();
                return Ok("Gruppe wurde nun erstellt");
            }
            else
            {
                return Ok(new { status = "ne" });
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the user.");
        }
    }
}