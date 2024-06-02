namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateUser
    {
        public DeleteAndUpdateUser() 
        {
        }

        public static void DeleteUser(int id)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.User returnObject = context.Users.FirstOrDefault(x => x.id == id);
            context.Users.Remove(returnObject);
        }  

        public static void UpdateUser(int id, string username, string email, int points, string utype, DateTime lastlogin, DateTime lastLogout, bool darkmode, DateTime birthdate)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.User returnObject = context.Users.FirstOrDefault(x => x.id == id);
            returnObject.username = username;
            returnObject.E_Mail = email;
            returnObject.points = points;
            returnObject.usertype = utype;
            returnObject.lastLogin = lastlogin;
            returnObject.lastLogout = lastLogout;
            returnObject.darkmode = darkmode;
            returnObject.birthDate = birthdate;

            context.Users.Update(returnObject);
        }
    }
}
