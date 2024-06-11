namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateGroup
    {
        public DeleteAndUpdateGroup() 
        {
        }

        public static void DeleteGroup(int id)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.Group returnObject = context.Groups.FirstOrDefault(x => x.id == id);
                context.Groups.Remove(returnObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etwas lief leider schief");
            }
        }  

        public static void UpdateGroup(int id, string name, int owner)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.Group returnObject = context.Groups.FirstOrDefault(x => x.id == id);
                returnObject.name = name;
                returnObject.owner = owner;

                context.Groups.Update(returnObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etwas lief leider schief");
            }
        }
    }
}
