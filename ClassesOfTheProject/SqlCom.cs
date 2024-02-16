using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MathMaster
{
    internal class SQLCom
    {
        private static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true");
        private static SqlCommand cmd = new SqlCommand("", conn);
        

        #region variablesAndConst.
        string _server, _database = "MathMaster", _username, _password;
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
            cmd.CommandText = "create database " + database;
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
                conn.ConnectionString = @"Data Soruce = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + database;
                cmd.CommandText = "CREATE TABLE User([id] INT NOT NULL PRIMARY KEY IDENTITY, [username] NVARCHAR(50)), [E-Mail] NVARCHAR(80), [points] INT," +
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
    }
}