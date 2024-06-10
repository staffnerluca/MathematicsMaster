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
            string imagePath = "ni";
            if(count != 0){
                Random r = new Random();
                int randomNum = r.Next(0, count);
                Models.Task task = context.Tasks.FirstOrDefault(x => x.nr == randomNum);
                return task;
            }//error with converting and returning, you need to fix this Lug
            return new Models.Task(taskNr, name, sector, difficulty, points, drawing, question, answer, source, group, imagePath);
        }

        //the task controller is flawed the number nr is that you get is the user id and you first need to read the user data to get the points
        public Models.Task GetTaskFromInput(string name)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Task? returnObject = context.Tasks.FirstOrDefault(x => x.name == name);
            if(returnObject == null){
                return GetRandomTask();
            }
            int nr = returnObject.nr;
            string sector = returnObject.sector;
            int difficulty = returnObject.difficulty + 10;
            int points = returnObject.points;
            bool drawing = returnObject.drawing;
            string quest = returnObject.question;
            string answer= returnObject.answer;
            string source = returnObject.source;
            int group = returnObject.group;
            string imagePath = returnObject.imagePath;

            Models.Task task = new Models.Task(nr, name, sector, difficulty, points, drawing, quest, answer, source, group, imagePath);
            return task;
        }
    }
}
