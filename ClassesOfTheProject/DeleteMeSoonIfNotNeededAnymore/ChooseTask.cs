using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MathMaster.ClassesOfTheProject.DeleteMeSoonIfNotNeededAnymore
{
    public class ChooseTask
    {
        public ChooseTask()
        {

        }

        public void ChooseYourTask(int id)
        {
            Models.User user = new Models.User();
            user.birthDate = "";
            user.points = 20;
            user.username = "username";
            //difficulty
            //history
            //different types of tasks
            //difficulty mode of the user

            //SQLCom sqlCom = new SQLCom();
            //sqlCom.GetUserById(id);
            //sqlCom.ChooseTheTask(); 
        }

        public void RandomTasks()
        {
            List<string[]> values = new List<string[]>();
            using (StreamReader reader = new StreamReader("D:\\MyFolder\\Files\\case.txt"))
            {
                while (!reader.EndOfStream)
                {
                    values.Add(reader.ReadLine().Split(','));
                }
            }
        }

    }
}
