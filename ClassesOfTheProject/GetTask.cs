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

            Models.Task task = (Models.Task)context.Tasks
            .FromSql($"SELECT * FROM dbo.Task WHERE nr = {nr}");

            return task;
        }
    }
}
