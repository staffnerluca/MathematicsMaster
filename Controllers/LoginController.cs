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
        try
        {
            //get data from form
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.User? returnObject = context.Users.FirstOrDefault(x => x.username == username); //loking if the User already exists, if yes then there comes the error of already existing
            try
            {
                if (returnObject != null)
                {
                    bool check = BCrypt.CheckPassword(password, returnObject.password); //checking if the passwort and hashed one are the same
                    bool login = false;
                    if (check == true)
                    {
                        return Ok(returnObject);
                    }
                    else
                    {
                        return Ok(new {status ="nf"}); //user not found
                    }
                }
                else
                {
                    return Ok(new {status ="nf"}); //also not found
                }
            }
            catch (System.NullReferenceException)
            {
                return BadRequest(new {status ="nf"}); //if it does throw the NullReferenceException then also not existing comes 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); //for me to check the error! 
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the user."); //double the time of checking is better than just one time checking I like to say...
        }

    }
}
