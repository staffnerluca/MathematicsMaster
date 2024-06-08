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
    public IActionResult Post(int group, int points, bool darkmode, int id)
    {
        string password = Request.Form["password"];
        HashPasswordForUse hashPassword = new HashPasswordForUse(password);
        string hashedpw = hashPassword.HashedPW();
      
        Models.User user = new Models.User();
        user.username = Request.Form["name"];
        user.E_Mail = Request.Form["mail"];
        user.points = points; 
        user.usertype = Request.Form["type"];
        user.lastLogin = Request.Form["lastLogin"];
        user.lastLogout = Request.Form["lastLogout"];
        user.birthDate = Request.Form["birthDate"];
        user.password = hashedpw;
        user.group = group;
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        context.Users.AddRange(user);
        context.SaveChanges();
        return Ok("User created");
    }
}
