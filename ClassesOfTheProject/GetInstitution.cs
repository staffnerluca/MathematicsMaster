using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MathMaster.ClassesOfTheProject
{
    public class GetInstitution    
    {
        public GetInstitution() 
        {
            
        }

        public Models.Institution GetInstitutionFromInput(int id)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();

            Models.Institution inst = (Models.Institution)context.Institutions
            .FromSql($"SELECT * FROM dbo.Înstitution WHERE id = {id}");

            return inst;
        }
    }
}
