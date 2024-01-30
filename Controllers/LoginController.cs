using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    //private SqlCom sql = new SqlCom();
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
    public IActionResult Post()
    {
        string username = Request.Form["username"];
        string password = Request.Form["password"];
        bool login = false;
        if(username == "l"){
            login = true;
        }
        return Ok(login);

    }

    //only for test purposes, delete later
    public Dictionary<string, string> CreateExampleDictionary(){
        Dictionary<string, string> users = new Dictionary<string, string>();
        users.Add("Lukas", "I<3Billiard123");
        users.Add("Alex", "3x+1");
        users.Add("Counting", "Sort");
        return users;
    }
}
