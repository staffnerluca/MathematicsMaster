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
            string adress = "";
            string country = "";
            string type = "";
            string phonenr = "";
            string email = "";
            string plz = "";

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Institution returnObject = context.Institutions.FirstOrDefault(x => x.id == id);
            returnObject.address = adress;
            returnObject.country = country;
            returnObject.type = type;
            returnObject.phoneNumber = phonenr;
            returnObject.mail = email;
            returnObject.postalCode = plz;

            Models.Institution inst = new Models.Institution(id, adress, country, type, phonenr, email, plz);
            return inst;
        }
    }
}
