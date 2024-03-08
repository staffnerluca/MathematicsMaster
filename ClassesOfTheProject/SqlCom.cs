using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;


namespace MathMaster
{
    internal class SQLCom
    {
        public static string _database = "MathMaster";
        private static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB" + _database + "; integrated security = true");
        private static SqlCommand cmd = new SqlCommand("", conn);

        User user;
        #region variablesAndConst.
        string _server, _username, _password;
        bool _integratedSecurity;
        public string server
        {
            get { return _server; }
            set { _server = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string database
        {
            get { return _database; }
            set { _database = value; }
        }

        public bool integratedSecurity
        {
            get { return _integratedSecurity; }
            set { _integratedSecurity = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public SQLCom()
        {

        }

        public SQLCom(string server, bool integratedSecurity)
        {
            this.server = server;
            this.integratedSecurity = integratedSecurity;
        }

        public SQLCom(string server, string database, bool integratedSecurity)
        {
            this.server = server;
            this.integratedSecurity = integratedSecurity;
            this.database = database;
        }
        public SQLCom(string server, string database, string password, bool integratedSecurity)
        {
            this.server = server;
            this.database = database;
            this.password = password;
            this.integratedSecurity = integratedSecurity;
        }
        #endregion

        public bool CheckForDatabase()
        {
            SqlCommand comm = new SqlCommand($"SELECT db_id('{database}')", conn);
            conn.Open();
            return comm.ExecuteScalar() != DBNull.Value;
        }

        public void CreateDatabase()
        {
            cmd.CommandText = "CREATE DATABASE " + database;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }

        public void CreateTables()
        {
            try
            {
                conn.Open();
                cmd.CommandText = "CREATE TABLE User([id] INT NOT NULL PRIMARY KEY IDENTITY, [username] NVARCHAR(50)), [E_Mail] NVARCHAR(80), [points] INT," +
                    " [userType] NVARCHAR(25), [lastLogin] DATETIME, [lastLogout] DATETIME, [darkmode] BOOL, [birthDate] DATETIME);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE UserAndGroups([UID] INT, [GID] INT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Group([id] INT NOT NULL PRIMARY KEY IDENTITY, [name] VARCHAR(50), [owner] INT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Institution([id] INT NOT NULL PRIMARY KEY IDENTITY, [address] NVARCHAR(100), [country] NVARCHAR(56)" +
                    ",[type] CHAR(1), [phoneNumber] NVARCHAR(20), [mail] NVARCHAR(40), [postalCode] NVARCHAR(16));";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE FinishedTasks([TaskID] INT, [UserID] INT, [Percent] FLOAT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Task([nr] INT, [name] NVARCHAR(50), [sector] CHAR(1), [difficulty] INT, [points] INT," +
                    "[drawing] BOOL, [question] NVARCHAR(3500), [answer] NVARCHAR(7500), [source] NVARCHAR(2000), [group] INT, [imagePath] NVARCHAR(1000));";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }

        public void AddGroup(int id, string name, int owner)
        {
            conn.Open();  
            cmd.CommandText = "INSERT INTO User (id, name, owner) VALUES (" + id + ", " + name + ", " + owner + ");";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateGroup(int id, string name, int owner)
        {
            conn.Open();
            cmd.CommandText = "UPDATE Group SET " + id + ", " + name + ", " + owner + ");";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteGroup(int id)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM Group WHERE id = " + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddUser(int id, string username, string E_Mail, int points, string userType, DateTime lastLogin, DateTime lastLogout, bool darkmode, DateTime birthDate)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO User (id, username, E_Mail, points, userType, lastLogin, lastLogout, darkmode, birthDate) VALUES (" + id + ", " + username + ", " + E_Mail + ", " + points + ", " + userType + ", " + lastLogin
                + ", " + lastLogout + ", " + darkmode + ", " + birthDate + ");";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateUser(int id, string username, string E_Mail, int points, string userType, DateTime lastLogin, DateTime lastLogout, bool darkmode, DateTime birthDate)
        {
            conn.Open();
            cmd.CommandText = "UPDATE User SET " + id + ", " + username + ", " + E_Mail + ", " + points + ", " + userType + ", " + lastLogin
                + ", " + lastLogout + ", " + darkmode + ", " + birthDate + ");";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteUser(int id)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM User WHERE id = " + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateTask(int nr, string name, char sector, int difficulty, int points, bool drawing, string question, string answer, string source, int group, string imagePath)
        {
            conn.Open();
            cmd.CommandText = "UPDATE Task SET " + nr + ", " + name + ", " + sector + ", " + difficulty + ", " + points + ", " + drawing 
                + ", " + question + ", " + answer + ", " + source + ", " + group + ", " + imagePath + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddTask(int nr, string name, char sector, int difficulty, int points, bool drawing, string question, string answer, string source, int group, string imagePath)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO Task (nr, name, sector, difficulty, points, drawing, question, answer, source, group, imagePath) VALUES (" + nr + ", " + name + ", " + sector + ", " + difficulty + ", " + points + ", " + drawing 
                + ", " + question + ", " + answer + ", " + source + ", " + group + ", " + imagePath + ");";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTask(int nr)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM Task WHERE nr = " + nr + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public User GetUserById(int id)
        {
            cmd.CommandText = "select * from User where id = " + id.ToString();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string username = reader.GetString(1);
            string useremail = reader.GetString(2);
            string password = reader.GetString(3);
            int points = reader.GetInt32(4);
            bool isTeacher = reader.GetBoolean(5);
            DateTime lastlogin = reader.GetDateTime(6);
            DateTime lastlogout = reader.GetDateTime(7);
            bool darkmode = reader.GetBoolean(8);
            DateTime birthdate = reader.GetDateTime(9);
            conn.Close();
            //select * from User where id = id
            user = new User(id, username, useremail, password, points, isTeacher, lastlogin, lastlogout, darkmode, birthdate);
            return user;
        }
        //user im User Klasse erstellen und dann mit SQL verknüpfen. 

        public Task ChooseTheTask()
        {
            //difficulty //Elo System
            int upper_bound = (int)Math.Round(user.points*1.2);
            int lower_bound = (int)Math.Round(user.points * 0.8);
            cmd.CommandText = "SELECT nr FROM Task WHERE difficulty >" + lower_bound.ToString() +" and difficulty <"+upper_bound.ToString();       
            Random rand = new Random();
            //get number of tasks between the bonds => choose a random one and read its data
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader getRandomTask = cmd.ExecuteReader();
            int id = getRandomTask.GetInt32(1); 
            rand.Next(id);
            cmd.CommandText = "SELECT * FROM Task WHERE nr" + rand;
            cmd.ExecuteNonQuery();
            //Reader or Table a Random Task

            SqlDataReader reader = cmd.ExecuteReader();
            int nr = reader.GetInt32(1);
            string name = reader.GetString(2);
            string sector = reader.GetString(3);
            int difficulty = reader.GetInt32(4);
            int points = reader.GetInt32(5);
            bool drawing = reader.GetBoolean(6);
            string question = reader.GetString(7);
            string answer = reader.GetString(8);
            string source = reader.GetString(9);
            int group = reader.GetInt32(10);
            string image = reader.GetString(11); 
            conn.Close();
            Task task = new Task(nr, name, sector, difficulty, points, drawing, question, answer, source, group, image);
            return task;
        }

        public void SampleUsers()
        {
            cmd.CommandText = "INSERT INTO Users (id, username, E_Mail, points, userType, lastLogin, lastLogout, darkmode, birthDate) VALUES (1, 'lukasr', 'lukas.resch@hak-kitz.ac.at', '120', );";
        }
    }
}