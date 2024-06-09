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
    public IActionResult Post(string name, int owner)
    {
        Models.Group group = new Models.Group(name, owner);
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        Models.Group returnObject = context.Groups.FirstOrDefault(x => x.name == name);
        if (returnObject.id != null)
        {
            int maxId = context.Groups.Max(u => (int?)u.id) ?? 0;
            //because there is a error in the DB design we need to find the new key
            group.id = maxId + 1;
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