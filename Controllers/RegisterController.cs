using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly ILogger<RegisterController> _logger;

    public RegisterController(ILogger<RegisterController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
    public IActionResult Post()
    {
        //User user = new User()
        string username = Request.Form["name"];
        string password = Request.Form["password"];;
        string mail = Request.Form["mail"];
        string group = Request.Form["group"];
        return Ok(username);
    }
}
