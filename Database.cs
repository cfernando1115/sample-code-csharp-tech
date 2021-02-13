using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SampleCodeTech
{
    public class Database
    {
        private SQLiteConnection _connection;
        private SQLiteCommand _command;
        private SQLiteDataReader _reader;
        private ILogger _logger;

        public Database(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateDbAndTable()
        {
            if (!File.Exists("sampledb.sqlite"))
            {
                SQLiteConnection.CreateFile("sampledb.sqlite");
                var table = @"CREATE TABLE Movies(
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name    TEXT    NOT NULL,
                    Genre   TEXT    NOT NULL,
                    Release REAL    NOT NULL
                );";

                _connection = new SQLiteConnection("Data Source=sampledb.sqlite");
                _connection.Open();
                _command = new SQLiteCommand(table, _connection);
                _command.ExecuteNonQuery();
                _connection.Close();
            }
            else
            {
                _connection = new SQLiteConnection("Data Source=sampledb.sqlite");
            }
        }

        public void AddMovie(Movie movie)
        {
            var formattedDate = movie.Release.ToString("yyyy-MM-dd");
            _command = new SQLiteCommand();
            _connection.Open();
            _command.Connection = _connection;
            _command.CommandText = "INSERT INTO Movies(Name, Genre, Release) VALUES('"+movie.Name+"', '"+movie.Genre+"', julianday('"+formattedDate+"'))";
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        public void GetMovie(int id) { }

        public void GetMovies() 
        {
            _command = new SQLiteCommand("SELECT Name, Genre, date(Release) FROM Movies", _connection);
            _connection.Open();
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                _logger.Log("Movie: " + _reader[0] + ", Genre: " + _reader[1] + ", Release Date: " + _reader[2]);
            }
        }
    }
}
