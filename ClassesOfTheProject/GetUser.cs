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
            string lastLogin = "";
            string lastLogout = "";
            string birthdate = "";
            string password = "";
            int group = 0;

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.User returnObject = context.Users.FirstOrDefault(x => x.id == uid);
            returnObject.username= username;
            returnObject.E_Mail = email;
            returnObject.points = points;
            returnObject.usertype = type;
            returnObject.lastLogin = lastLogin;
            returnObject.lastLogout = lastLogout;
            returnObject.birthDate = birthdate;
            returnObject.password = password;
            returnObject.group = group;

            Models.User user = new Models.User(uid, username, email, points, type, lastLogin, lastLogout, birthdate, password, group);
            return user;
        }
    }
}
