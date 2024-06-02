using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MathMaster.ClassesOfTheProject
{
    public class GetUser   
    {
        public GetUser() 
        {
            
        }

        public Models.User GetUserFromInput(int uid)
        {
            string username = "";
            string email = "";
            int points = 0;
            string type = "";
            DateTime lastLogin = DateTime.Now;
            DateTime lastLogout = DateTime.Now;
            bool darkmode = false;
            DateTime birthdate = DateTime.Now;

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.User returnObject = context.Users.FirstOrDefault(x => x.id == uid);
            returnObject.username= username;
            returnObject.E_Mail = email;
            returnObject.points = points;
            returnObject.usertype = type;
            returnObject.lastLogin = lastLogin;
            returnObject.lastLogout = lastLogout;
            returnObject.darkmode = darkmode;
            returnObject.birthDate = birthdate;

            Models.User user = new Models.User(uid, username, email, points, type, lastLogin, lastLogout, darkmode, birthdate);
            return user;
        }
    }
}
