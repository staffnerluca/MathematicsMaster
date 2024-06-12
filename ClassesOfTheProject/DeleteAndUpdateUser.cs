﻿namespace MathMaster.ClassesOfTheProject
{
    public class DeleteAndUpdateUser
    {
        public DeleteAndUpdateUser() 
        {
        }

        public static void DeleteUser(int id)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.User returnObject = context.Users.FirstOrDefault(x => x.id == id);
                context.Users.Remove(returnObject); //deleting the object
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
        }  

        public static void UpdateUser(int id, string username, string email, int points, string utype, string lastlogin, string lastLogout, string birthdate, string password, int group)
        {
            try
            {
                Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
                Models.User returnObject = context.Users.FirstOrDefault(x => x.id == id);
                returnObject.username = username;
                returnObject.E_Mail = email;
                returnObject.points = points;
                returnObject.usertype = utype;
                returnObject.lastLogin = lastlogin;
                returnObject.lastLogout = lastLogout;
                returnObject.birthDate = birthdate;
                returnObject.password = password;
                returnObject.group = group;

                context.Users.Update(returnObject); //with update logically I can update my user
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}