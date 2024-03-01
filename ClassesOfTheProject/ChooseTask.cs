namespace MathMaster.ClassesOfTheProject
{
    public class ChooseTask
    {
        ChooseTask(int userID) 
        {
            
        }

        public int GetTaskID(int id)
        {
            //difficulty
            //history
            //different types of tasks
            //difficulty mode of the user
            SQLCom sqlCom = new SQLCom();
            sqlCom.GetUserById(id);
            sqlCom.ChooseTask(); 
            return 0;
        }

    }
}
