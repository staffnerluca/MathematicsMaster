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

    [HttpGet]
    public IActionResult Get(int id)
    {
        try
        {
            GetInstitution inst = new GetInstitution();
            inst.GetInstitutionFromInput(id);
            return Ok("works");
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while becoming a organisation.");
        }
        
    }

    [HttpPost]
    public IActionResult Post(int id, string adress, string country, string type, string phonenr, string email, string plz)
    {
        try
        {
            Models.Institution institution = new Models.Institution(id, adress, country, type, phonenr, email, plz);
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Institution returnObject = context.Institutions.FirstOrDefault(x => x.id == id); //seaching for id, to know if organisation does exist
            if (returnObject != null)
            {
                context.Institutions.Add(institution);
                context.SaveChanges();
                return Ok("works");
            }
            else
            {
                return Ok("Organisation does exist!");
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the organisation.");
        }
       
    }
}

