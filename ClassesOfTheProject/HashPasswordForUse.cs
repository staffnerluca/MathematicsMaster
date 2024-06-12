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
            string salt = BCrypt.GenerateSalt(12); //just generating salt with some rounds
            string hashedpassword = BCrypt.HashPassword(password, salt); //hashing the password with the BCrypt class and then afterwards returning the hashed one.
            return hashedpassword;
        }
    }
}