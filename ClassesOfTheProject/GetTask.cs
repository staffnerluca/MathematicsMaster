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
            Models.Task returnObject = context.Tasks.FirstOrDefault(x => x.nr == nr);
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
