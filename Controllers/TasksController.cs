using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    //HTTP Get TaskController: Soll ihm dann einen Task geben
    //HTTP Post: Bekomme Daten und soll daraus den Task erstellen

    [HttpGet]
    public IActionResult Get(int userID)
    {
        Dictionary<string, string> task = new Dictionary<string, string>();
        task.Add("name", "first task");
        task.Add("question", "1 + 1 = ");
        task.Add("answer", "2");
        return Ok(task);
    }

    [HttpPost]
    public IActionResult Post()
    {
        Dictionary<string, string> task = new Dictionary<string, string>();
        task.Add("name", "first task");
        task.Add("question", "1 + 1 = ");
        task.Add("answer", "2");
        return Ok(task);
    }

    //only for test purposes, delete later
    public Dictionary<string, string> CreateExampleTask() 
    {
        Dictionary<string, string> task = new Dictionary<string, string>();
        task.Add("Nr", "1");
        task.Add("name", "Gewinnspiel");
        task.Add("question", @"Auf dem Etikett einer Getränkeflasche ist ein Code für ein Gewinnspiel aufgedruckt.
        \n • Die Wahrscheinlichkeit, mit diesem Code einen Gewinn von € 10 zu erzielen, beträgt 1 %.\n 
        • Die Wahrscheinlichkeit, mit diesem Code einen Gewinn von € 2 zu erzielen, beträgt 4 %. \n 
        Es gibt keine weiteren Gewinne. Die Zufallsvariable X gibt den Gewinn (in €) für einen Code an.\n \n
        Aufgabenstellung:\n
        Berechnen Sie den Erwartungswert E(X).");
        task.Add("answer", "0,18");
        return task;
    }

        public Dictionary<string, string> CreateExampleDictionary()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("Lukas", "I<3Billiard123"); //#BillardForLive 
            users.Add("Alex", "3x+1");
            users.Add("Counting", "Sort");
            return users;
        }
    }

