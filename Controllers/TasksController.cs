using MathMaster.ClassesOfTheProject;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger; //to login in the taskcontroller

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get(int points)
    {
        try
        {
            //we are just getting the task from our class and their method and returning the task
            GetTask taskGetter = new GetTask();
            Models.Task task = taskGetter.GetTaskFromInput(points);
            return Ok(task);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while trying to find a task.");
        }
    }

    [HttpPost]
    public IActionResult Post()
    {
        try
        {
            string name = Request.Form["name"]; //getting the variable name from the frontend
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Task? returnObject = context.Tasks.FirstOrDefault(x => x.name == name); //searching for the name, which is unique
            if (returnObject == null) //if there is nothing we can create a new task
            {
                Models.Task task = new Models.Task();
                int maxId = context.Tasks.Max(u => (int?)u.nr) ?? 0; //here we are looking at the maximum number, int is nullable, and then our standard value is 0

                task.nr = maxId + 1;
                task.name = Request.Form["name"];
                task.sector = Request.Form["type"];
                task.difficulty = Int32.Parse(Request.Form["difficulty"]); //we have to parse this, because there is no int available at JSON (which is the return variable)
                task.points = Int32.Parse(Request.Form["difficulty"]); //points and difficulty we did give the same value, because that would of be a feature we might add later on
                task.drawing = false; //feature for later
                task.question = Request.Form["question"];
                task.answer = Request.Form["answer"];
                task.source = "";
                task.group = 0; //feature for later
                task.imagePath = "";

                context.Tasks.Add(task); //adds the task
                context.SaveChanges(); //saves the task
                return Ok(new { status = "Task erstellt!" }); //status, that frontend can read it
            }
            else
            {
                return Ok(new { status = "Task existiert bereits!" }); //status, that frontend can read it
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the task.");
        }
    }
}

