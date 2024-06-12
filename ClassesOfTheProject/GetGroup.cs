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

        public Models.Group GetGroupFromInput(string name)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Group? returnObject = context.Groups.FirstOrDefault(x => x.name == name); //gets the group by a unique name
            int id = returnObject.id;
            int owner = returnObject.owner;

            Models.Group group = new Models.Group(id, name, owner);
            return group;
        }
    }
}
