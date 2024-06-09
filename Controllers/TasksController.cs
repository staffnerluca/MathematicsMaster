using System.Data.SqlTypes;
using MathMaster.ClassesOfTheProject;
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

    [HttpGet]
    public IActionResult Get(int id)
    {
        GetTask task = new GetTask();
        task.GetTaskFromInput(id);
        return Ok("works");
    }

    [HttpPost]
    public IActionResult Post()
    {
        /*
        Task task = new Task();
        task.answer = Request.Form["name"];
        task.difficulty = Int32.Parse(Request.Form["difficulty"]);
        string answer = Request.Form["answer"];
        string sec
        */
        return Ok("works"); 
    }

    //only for test purposes, delete later
    public Dictionary<string, string> CreateExampleTask() 
    {
        Dictionary<string, string> task = new Dictionary<string, string>();
        task.Add("Nr", "1");
        task.Add("name", "Gewinnspiel");
        task.Add("question", @"Auf dem Etikett einer Getr�nkeflasche ist ein Code f�r ein Gewinnspiel aufgedruckt.
        \n � Die Wahrscheinlichkeit, mit diesem Code einen Gewinn von � 10 zu erzielen, betr�gt 1 %.\n 
        � Die Wahrscheinlichkeit, mit diesem Code einen Gewinn von � 2 zu erzielen, betr�gt 4 %. \n 
        Es gibt keine weiteren Gewinne. Die Zufallsvariable X gibt den Gewinn (in �) f�r einen Code an.\n \n
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

