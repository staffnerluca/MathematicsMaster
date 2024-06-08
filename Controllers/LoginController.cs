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
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        Models.User returnObject = context.Users.FirstOrDefault(x => x.username == username);
        try
        {
            if (returnObject != null)
            {
                bool check = BCrypt.CheckPassword(password, returnObject.password);
                bool login = false;
                if (check == true)
                {
                    login = true;
                }
                else
                {
                    return Ok("Problem mit Username Passwort");
                }
                return Ok(login);
            }
            else
            {
                return Ok("User gibt es nicht"); 
            }
        }
        catch (System.NullReferenceException)
        {
            return BadRequest("Den User gibt es nicht");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
