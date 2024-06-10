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
    public IActionResult Get(int id)
    {
        GetGroup group = new GetGroup();
        group.GetGroupFromInput(id);
        return Ok("ok");
    }

    [HttpPost]
    public IActionResult Post()
    {
        string name = Request.Form["name"];
        int owner = Int32.Parse(Request.Form["userid"]);
        Console.WriteLine(name);
        Console.WriteLine(owner);
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        int lastId = context.Users.Max(u => (int?)u.id) ?? 0;

        Models.Group group = new Models.Group(lastId+1, name, owner);
        Models.Group? returnObject = context.Groups.FirstOrDefault(x => x.name == name);
        if (returnObject != null)
        {
            context.Groups.Add(group);
            context.SaveChanges();
            return Ok("funktioniert");
        }
        else
        {
            return Ok("Gruppe existiert bereits!");
        }
    }
}