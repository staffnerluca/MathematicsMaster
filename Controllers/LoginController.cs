using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
    public IActionResult Post()
    {
        //get data from form
        string username = Request.Form["username"];
        string password = Request.Form["password"];
        bool login = false;
        if(username == "l")
        {
            login = true;
        }
        return Ok(login);
    }
}
