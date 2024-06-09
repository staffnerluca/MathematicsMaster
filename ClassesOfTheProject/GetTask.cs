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
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Task returnObject = context.Tasks.FirstOrDefault(x => x.nr == nr);
            string name = returnObject.name;
            string sector = returnObject.sector;
            int difficulty = returnObject.difficulty;
            int points = returnObject.points;
            bool drawing = returnObject.drawing;
            string quest = returnObject.question;
            string answer = returnObject.answer;
            string source = returnObject.source;
            int group = returnObject.group;
            string imagePath = returnObject.imagePath;

            Models.Task task = new Models.Task(nr, name, sector, difficulty, points, drawing, quest, answer, source, group, imagePath);
            return task;
        }
    }
}
