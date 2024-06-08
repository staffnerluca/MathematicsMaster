using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using System.Drawing.Drawing2D;

namespace MathMaster
{
    public class HashPasswordForUse()
    {
        public string HashedPW(string password)
        {
            string salt = BCrypt.GenerateSalt(12);
            string hashedpassword = BCrypt.HashPassword(password, salt);
            return hashedpassword;
        }

        public void Test(string password1, string name, string mail,
            int points, string type, string lastLogin, string lastLogout,
            string birthDate, int group)
        {
            Models.User user = new Models.User();
            user.id = 201;
            user.username = name;
            user.E_Mail = mail;
            user.points = points;
            user.usertype = type;
            user.lastLogin = lastLogin;
            user.lastLogout = lastLogout;
            user.birthDate = birthDate;
            user.password = password1;
            user.group = group;

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}