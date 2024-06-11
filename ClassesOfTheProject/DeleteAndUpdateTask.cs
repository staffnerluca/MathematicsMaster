namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateTask
    {
        public DeleteAndUpdateTask()
        {
        }

        public static void DeleteTask(int id)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.Task returnObject = context.Tasks.FirstOrDefault(x => x.nr == id);
                context.Tasks.Remove(returnObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etwas lief leider schief");
            }
        }

        public static void UpdateTask(int nr, string name, string sector, int difficulty, int points, bool drawing, string question, string answer, string source, int group, string image)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.Task returnObject = context.Tasks.FirstOrDefault(x => x.nr == nr);
                returnObject.name = name;
                returnObject.sector = sector;
                returnObject.difficulty = difficulty;
                returnObject.points = points;
                returnObject.drawing = drawing;
                returnObject.question = question;
                returnObject.answer = answer;
                returnObject.source = source;
                returnObject.group = group;
                returnObject.imagePath = image;

                context.Tasks.Update(returnObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etwas lief leider schief");
            }
        }
    }
}
