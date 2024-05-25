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
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();

            Models.User user = (Models.User)context.Users
            .FromSql($"SELECT * FROM dbo.User WHERE id = {uid}");

            return user; 
        }
    }
}
