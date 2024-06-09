namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateInstitution
    {
        public DeleteAndUpdateInstitution() 
        {
        }

        public static void DeleteInstitution(int id)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Institution returnObject = context.Institutions.FirstOrDefault(x => x.id == id);
            context.Institutions.Remove(returnObject);
        }  

        public static void UpdateInstitution(int id, string adress, string country, string type, string phonenr, string email, string plz)
        {
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            Models.Institution returnObject = context.Institutions.FirstOrDefault(x => x.id == id);
            returnObject.address = adress;
            returnObject.country = country;
            returnObject.type = type;
            returnObject.phoneNumber = phonenr;
            returnObject.mail = email;
            returnObject.postalCode = plz;

            context.Institutions.Update(returnObject);
        }
    }
}
