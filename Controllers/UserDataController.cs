using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDataController : ControllerBase
{
    //private SqlCom sql = new SqlCom();
    private readonly ILogger<UserDataController> _logger;

    public UserDataController(ILogger<UserDataController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
    public bool Post(string username, string password)
    {
        Dictionary<string, string> users = CreateExampleDictionary();
        //Dictionary<string, string> users = SqlCom.GetUsernameAndPassword();

        //TODO: use Hash function on the password
        if(users.ContainsKey(username)){
            //users[username] = the stored password (hashed)
            if(users[username] == password){
                return true;
            }
        }
        return false;

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
