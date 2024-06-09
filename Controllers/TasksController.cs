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
    public IActionResult Get(int nr)
    {
        GetTask task = new GetTask();
        task.GetTaskFromInput(nr);
        return Ok("works");
    }

    [HttpPost]
    public IActionResult Post(int nr, string name, string sector, int difficulty, int points, bool drawing, string question, string answer, string source, int group, string image)
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

