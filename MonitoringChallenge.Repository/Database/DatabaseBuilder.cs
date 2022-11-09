using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Repository
{
    public class DatabaseBuilder : IDatabaseBuilder
    {
        private readonly DatabaseConfig _databaseConfig;

        public DatabaseBuilder(DatabaseConfig databaseConfig)
        {   
            _databaseConfig = databaseConfig;

        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Server';");
            var tableName = table.FirstOrDefault();

            if (string.IsNullOrEmpty(tableName) && tableName != "Server") 
            {
                connection.Execute("Create Table Server (" +
                "Id VARCHAR(100) NOT NULL," +
                "Name VARCHAR(100) NOT NULL," +
                "IpAddress VARCHAR(100) NOT NULL," +
                "Port INTEGER NOT NULL," +
                "Status BIT NOT NULL);");
            }

            table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'VideoFile';");
            tableName = table.FirstOrDefault();

            if (string.IsNullOrEmpty(tableName) && tableName != "VideoFile")
            {
                connection.Execute("Create Table VideoFile (" +
                "Id VARCHAR(100) NOT NULL," +
                "ServerId VARCHAR(100) NOT NULL," +
                "Description VARCHAR(100) NOT NULL," +
                "File BLOB NOT NULL," +
                "Created DATETIME NOT NULL);");
            }
        }
    }
}
