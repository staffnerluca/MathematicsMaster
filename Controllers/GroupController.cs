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
        return Ok("works");
    }

    [HttpPost]
    public IActionResult Post(int id, string name, int owner)
    {
        Models.Group group = new Models.Group(id, name, owner);
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        context.Groups.Add(group);
        context.SaveChanges();
        return Ok("funktioniert");
    }
}