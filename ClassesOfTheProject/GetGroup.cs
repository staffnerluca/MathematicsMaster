using MathMaster.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MathMaster.ClassesOfTheProject
{
    public class GetGroup    
    {
        public GetGroup() 
        {
            
        }

        public Models.Group GetGroupFromInput(int id)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Group returnObject = context.Groups.FirstOrDefault(x => x.id == id);
            string name = returnObject.name;
            int owner = returnObject.owner;

            Models.Group group = new Models.Group(name, owner);
            return group;
        }
    }
}
