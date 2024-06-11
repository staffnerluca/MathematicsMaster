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
    public IActionResult Get(string name)
    {
        GetTask task = new GetTask();
        task.GetTaskFromInput(name);
        Console.WriteLine(task);
        return Ok(task);
    }

    [HttpPost]
    public IActionResult Post()
    {
        string name = Request.Form["name"];
        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        Models.Task? returnObject = context.Tasks.FirstOrDefault(x => x.name == name);
        if (returnObject == null)
        {
            Models.Task task = new Models.Task();
            int maxId = context.Tasks.Max(u => (int?)u.nr) ?? 0;

            task.nr = maxId + 1;
            task.name = Request.Form["name"];
            task.sector = Request.Form["sector"];
            task.difficulty = Int32.Parse(Request.Form["difficulty"]);
            task.points = Int32.Parse(Request.Form["difficulty"]);
            task.drawing = false;
            task.question = Request.Form["question"];
            task.answer = Request.Form["answer"];
            task.source = "";
            task.group = Int32.Parse(Request.Form["group"]);
            Console.WriteLine(Int32.Parse(Request.Form["group"]));
            task.imagePath = "";

            context.Tasks.Add(task);
            context.SaveChanges();
            return Ok("Task erstellt!");
        }
        else
        {
            return Ok("Gruppe existiert bereits!");
        }
      
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

