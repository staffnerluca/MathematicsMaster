/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MSSQLManager
{
    internal class SQLCom
    {
        private static SqlConnection conn = new SqlConnection("");
        private static SqlCommand cmd = new SqlCommand("", conn);

        #region variablesAndConst.
        string _server, _database = "", _username, _password;
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
            set { _integratedSecurity = value;}
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

        public void ConnectToServer()
        {
            if (integratedSecurity)
                conn.ConnectionString = @"Server=" + server + "; Integrated Security=True";
            else
                conn.ConnectionString = @"server=" + server + "; password=" + password;
        }

        public List<String> ShowDatabases()
        {
            //returns a list with the names of all databases in it
            List<String> showDatabases = new List<String>();
            cmd.CommandText = "select name from sys.databases";
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    showDatabases.Add(reader["name"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex) { }
            return showDatabases;
        }

        public void CreateDatabase()
        {
            cmd.CommandText = "create database " + database;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch(Exception ex) {}
        }

        public List<String> ShowTables()
        {
            //returns list with the names all tables in it
            List<String> showTables = new List<String>();
            cmd.CommandText = "SELECT table_name FROM information_schema.tables";
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    showTables.Add(reader["table_name"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex) { }
            return showTables;
        }

        public DataTable GetTableData(string table)
        {
            DataTable dTable = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from " + table,conn);
                adapter.Fill(dTable);
                conn.Close();
            }catch (Exception ex) {}
            return dTable;
        }

        public void CreateTableFromUser(List<string> names, List<string> dataTypes, List<bool> isPrim, List<bool> notNull)
        {
            //names[0] = tableName.Text
            string command = "create table " + names[0] + "(";
            for (int i = 0; i < notNull.Count; i++)
            {
                command += names[i + 1] + " " + dataTypes[i];
                if (isPrim[i])
                    command += " Primary Key";
                if (notNull[i])
                    command += " not null";
                if (i + 1 < notNull.Count)
                    command += ", ";
                else
                    command += ")";
            }
            try
            {
                conn.Open();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch(Exception ex) { }
        }
        
        public void ChangeTableName(string oldName, string newName)
        {
            cmd.CommandText = "EXEC sp_rename '" + oldName + "' , '" + newName + "'";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch(Exception ex) {}
        }

        public void ChangeDatabaseName(string oldName, string newName)
        {
            cmd.CommandText = "EXEC sp_renamedb '" + oldName + "' , '" + newName + "'";
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex) {}

        }

        public void UpdateDatabaseFromDataGridview(DataTable dt, string table)
        {
            cmd.CommandText = "truncate table " + table;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.DestinationTableName = table;
                copy.WriteToServer(dt);
                conn.Close();
            }catch(Exception ex){ }
        }

        public void DeleteDatabase(string dbName)
        {
            cmd.CommandText = "drop database " + dbName;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch (Exception ex){ }

        }

        public void DeleteTable(string tbName)
        {
            cmd.CommandText = "drop table " + tbName;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch(Exception e){ }
        }
    }
}*/