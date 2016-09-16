using log4net;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPUpdater
{
    class DatabaseHelper
    {
        // Configure logger
        ILog log = LogManager.GetLogger(typeof(DatabaseHelper));

        string connectionString = @"Data Source=./Updates/updateDB.sqlite;Version=3;";


        public DatabaseHelper()
        {
            if(File.Exists(@"./Updates/updateDB.sqlite"))
            {
                log.Info("Found database");
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=./Updates/updateDB.sqlite;Version=3;");
                try
                {
                    using (connection)
                    {
                        connection.Open();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            log.Info("Successfully opened connection to the database");
                            connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }
            else
            {
                log.Info("Database not found. Creating one...");
                SQLiteConnection.CreateFile("./Updates/updateDB.sqlite");
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=./Updates/updateDB.sqlite");
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS SPUpdate (guid TEXT, kb_number TEXT, status TEXT, file_name TEXT);";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                log.Info("Done creating database");
                connection.Close();
            }
        }

        public void AddPatch(string guid, string kbnumber, Update.UpdateStatus status, string file_name)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO spupdate (guid, kb_number, status, file_name) VALUES (" + guid +"," + kbnumber + "," + status + "," + file_name + ")";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdatePatch()
        {

        }
    }
}
