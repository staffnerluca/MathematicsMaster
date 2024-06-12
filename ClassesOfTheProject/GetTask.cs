using MathMaster.ClassesOfTheProject;
using MathMaster.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MathMaster.ClassesOfTheProject
{
    public class GetTask    
    {
        public GetTask() 
        {
            
        }

        public Models.Task GetRandomTask(){
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            //gets the number of tasks 
            int count = context.Tasks.Count();
            int taskNr = 0;
            string name = "dieter"; 
            string sector = "A";
            int difficulty = 20;
            int points = 20;
            bool drawing = false; 
            string question = "Is it your fault that it is default? (No tasks created for your group. Create one to change that)";
            string answer = "I will create one";
            string source = "my brain";
            int group = 0;
            string imagePath = "";
            if(count != 0)
            {
                Random r = new Random();
                int randomNum = r.Next(0, count); //looks at how many tasks there are and gets a random one
                Models.Task task = context.Tasks.FirstOrDefault(x => x.nr == randomNum);
                return task;
            }
            return new Models.Task(taskNr, name, sector, difficulty, points, drawing, question, answer, source, group, imagePath);
        }

        //the task controller is flawed the number nr is that you get is the user id and you first need to read the user data to get the points
        public Models.Task GetTaskFromInput(int points)
        {
            //here with int max and int min we try to create a new difficulty, when a user has the right answer.
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            int max = (int)Math.Round(Double.Parse(points.ToString())*1.1); //rounding it, because we don't got a double value
            int min = (int)Math.Round(Double.Parse(points.ToString()) * 0.9); //rounding it, because we don't got a double value
            List<Models.Task> tasks = context.Tasks.Where(t =>  t.points >= min && t.points <= max).ToList(); //creating a list where we have all tasks in there, matching our wanted points
            if (tasks.Count == 0) //if there are zero tasks maching we get a random one
            {
                Models.Task mytask = GetRandomTask();
                return mytask;
            }
            Random random = new Random();
            int r = random.Next(0, tasks.Count-1); //here we are getting our task, -1 to fix the problem of an exception
            Models.Task? returnObject = tasks[r]; //here we just get our different tasks, if it is null, then we get a random one
            if (returnObject == null){
                return GetRandomTask();
            }
            string name = returnObject.name;
            int nr = returnObject.nr;
            string sector = returnObject.sector;
            int difficulty = returnObject.difficulty;
            bool drawing = returnObject.drawing;
            string quest = returnObject.question;
            string answer= returnObject.answer;
            string source = returnObject.source;
            int group = returnObject.group;
            string imagePath = returnObject.imagePath;

            Models.Task task = new Models.Task(nr, name, sector, difficulty, points, drawing, quest, answer, source, group, imagePath); //creating new task and returning it for Luca
            return task;
        }
    }
}
