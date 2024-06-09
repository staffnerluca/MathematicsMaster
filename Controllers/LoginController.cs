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
        //try
        //{
            if (returnObject != null)
            {
                bool check = BCrypt.CheckPassword(password, returnObject.password);
                bool login = false;
                if (check == true)
                {
                    return Ok(returnObject);
                }
                else
                {
                    return Ok("nf");
                }
            }
            else
            {
                return Ok("nf"); 
            }
        }
        /*catch (System.NullReferenceException)
        {
            return BadRequest("nf");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }*/
    //}
}
