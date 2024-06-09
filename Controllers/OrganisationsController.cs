using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using MathMaster.ClassesOfTheProject;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganisationsController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public OrganisationsController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    //HTTP Get TaskController: Soll ihm dann einen Task geben
    //HTTP Post: Bekomme Daten und soll daraus den Task erstellen

    [HttpGet]
    public IActionResult Get(int id)
    {
        GetInstitution inst = new GetInstitution();
        inst.GetInstitutionFromInput(id);
        return Ok("works");
    }

    [HttpPost]
    public IActionResult Post(int id, string adress, string country, string type, string phonenr, string email, string plz)
    {
        Models.Institution institution = new Models.Institution(id, adress, country, type, phonenr, email, plz);
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        Models.Institution returnObject = context.Institutions.FirstOrDefault(x => x.id == id);
        if (returnObject != null)
        {
            context.Institutions.Add(institution);
            context.SaveChanges();
            return Ok("funktioniert");
        }
        else
        {
            return Ok("Gruppe existiert bereits!");
        }
    }
}

