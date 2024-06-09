using System;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Org.BouncyCastle.Crypto.Generators;

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
        //try
        //{
            string name = Request.Form["name"];
            string mail = Request.Form["mail"];
            string password = Request.Form["password"];
            int group = Convert.ToInt32(Request.Form["group"]);
            string birthDate = Request.Form["birthdate"];
            string type = Request.Form["type"];
            
            HashPasswordForUse hashPassword = new HashPasswordForUse();
            string hashedPassword = hashPassword.HashedPW(password);

            Models.User user = new Models.User
            {
                username = name,
                E_Mail = mail,
                points = 20,
                usertype = type,
                lastLogin = DateTime.Now.ToString(),
                lastLogout = DateTime.Now.ToString(),
                birthDate = birthDate,
                password = hashedPassword,
                group = group
            };

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            context.Users.Add(user);
            context.SaveChanges();
            
            return Ok("User created");
        //}
        /*
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the user." );
        }*/
    }
}
