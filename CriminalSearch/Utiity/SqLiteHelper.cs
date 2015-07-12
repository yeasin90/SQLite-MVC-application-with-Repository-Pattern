using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CriminalSearch.Utility
{
    public class SqLiteHelper
    {
        private readonly string _dataSource;
        private SQLiteConnection _con;
        private SQLiteCommand _com;

        public SqLiteHelper(string dataSource)
        {
            _dataSource = dataSource;
        }

        public void InitializeData()
        {
            if (!File.Exists(_dataSource))
                SQLiteConnection.CreateFile(_dataSource);

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [User] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Username] NVARCHAR(2048)  NULL,
                          [Email] NVARCHAR(2048)  NULL,
                          [Password] NVARCHAR(2048)  NULL
                          )";

            ExecuteNonQuery(createTableQuery);

            createTableQuery = @"CREATE TABLE IF NOT EXISTS [Criminal] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Name] NVARCHAR(2048)  NOT NULL,
                          [Email] NVARCHAR(2048) NOT NULL,
                          [Age] INTEGER  NOT NULL,
                          [Sex] INTEGER  NOT NULL,
                          [Height] FLOAT NOT NULL,
                          [Nationality] NVARCHAR(2048)  NOT NULL
                          )";

            ExecuteNonQuery(createTableQuery);

            double[] height = new double[15] { 5.1, 5.2, 5.3, 5.4, 5.5, 5.6, 5.7, 5.8, 5.9, 5.10, 5.11, 5.12, 6.1, 6.2, 6.3 };

            for (int i = 1; i <= 15; i++)
            {
                string name = "Criminal" + i;
                string email = "crim" + i + "@yahoo.com";
                string country = "Country" + i;

                string query = "INSERT INTO Criminal (Name,Email,Age,Sex,Height,Nationality) Values " +
                              " ('" + name + "','" + email + "'," + (i + 20) + ",0," + height[i - 1] + ",'" + country + "')";

                ExecuteNonQuery(query);
            }
        }

        public SQLiteDataReader ExecuteCommand(string query, out SQLiteConnection connection)
        {
            SQLiteDataReader reader;
            connection = new SQLiteConnection("data source="+_dataSource);
            _com = new SQLiteCommand(connection);
            connection.Open();
            _com.CommandText = query;      // Select all rows from our database table
            reader = _com.ExecuteReader();
            return reader;
        }

        public void ExecuteNonQuery(string query)
        {
            using (_con = new SQLiteConnection("data source=" + _dataSource))
            {
                using (_com = new SQLiteCommand(_con))
                {
                    _con.Open();
                    _com.CommandText = query;
                    _com.ExecuteNonQuery();
                    _con.Close();
                }
            }
        }
    }
}
