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

        public async Models.Task GetRandomTask(){
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            //gets the number of tasks 
            int count = await context.Tasks.CountAsync();
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
                Model.Task task = context.Tasks.FirstOrDefault(x => x.nr == randomNum);
                return task;
            }//error with converting and returning, you need to fix this Lug
            return new Model.Task(taskNr, name, sector, difficulty, points, drawing, question, answer, source, group, imagePath);
        }

        public Models.Task GetTaskFromInput(int nr)
        {
            string name = ""; 
            string sector = "";
            int difficulty = 0;
            int points = 0;
            bool drawing = false; 
            string quest = "";
            string answer = "";
            string source = "";
            int group = 0;
            string imagePath = "";

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Task? returnObject = context.Tasks.FirstOrDefault(x => x.nr == nr);
            if(returnObject == null){
                returnObject = GetRandomTask();
            }
            returnObject.name = name;
            returnObject.sector = sector;
            returnObject.difficulty = difficulty + 100;
            returnObject.points = points;
            returnObject.drawing = drawing;
            returnObject.question = quest;
            returnObject.answer = answer;
            returnObject.source = source;
            returnObject.group = group;
            returnObject.imagePath = imagePath;

            Models.Task task = new Models.Task(nr, name, sector, difficulty, points, drawing, quest, answer, source, group, imagePath);
            return task;
        }
    }
}
