using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    //private SqlCom sql = new SqlCom();
    private readonly ILogger<UserDataController> _logger;

    public TaskController(ILogger<UserDataController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Get(string filter, string username){
        //return allTasks that fullfill the requirement of the filter
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
