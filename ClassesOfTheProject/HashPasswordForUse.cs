using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using System.Drawing.Drawing2D;

namespace MathMaster
{
    public class HashPasswordForUse(string password)
    {
        public string HashedPW()
        {
            string salt = BCrypt.GenerateSalt(2);
            string hashedpassword = BCrypt.HashPassword(password, salt);
            return hashedpassword;
        }

        public void Test(string password1, string name, string mail,
            int points, string type, string lastLogin, string lastLogout,
            string birthDate, int group)
        {
            string password = password1;
            HashPasswordForUse hashPassword = new HashPasswordForUse(password);
            string hashedpw = hashPassword.HashedPW();

            Models.User user = new Models.User();
            user.username = name;
            user.E_Mail = mail;
            user.points = points;
            user.usertype = type;
            user.lastLogin = lastLogin;
            user.lastLogout = lastLogout;
            user.birthDate = birthDate;
            user.password = hashedpw;
            user.group = group;
            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            context.Users.AddRange(user);
            context.SaveChanges();
        }
    }
}