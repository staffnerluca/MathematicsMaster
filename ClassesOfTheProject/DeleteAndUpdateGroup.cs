namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateGroup
    {
        public DeleteAndUpdateGroup() 
        {
        }

        public static void DeleteGroup(int id)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Group returnObject = context.Groups.FirstOrDefault(x => x.id == id);
            context.Groups.Remove(returnObject);
        }  

        public static void UpdateGroup(int id, string name, int owner)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Group returnObject = context.Groups.FirstOrDefault(x => x.id == id);
            returnObject.name = name;
            returnObject.owner = owner;

            context.Groups.Update(returnObject);
        }
    }
}
