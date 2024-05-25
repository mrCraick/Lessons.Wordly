using Microsoft.Data.Sqlite;

namespace Lessons.Wordly.Infrastructure;

public class ConnectionStringProvider
{
    private readonly string _dbName;

    public ConnectionStringProvider(string dbName)
    {
        _dbName = dbName;
    }

    public string GetConnectionString()
    {
        var connectionString = $"Data Source={Path.Combine(Environment.CurrentDirectory, _dbName)};";
        
        var migrate = File.ReadAllText("Scripts/words-russian-nouns.sql");

        using var connection = new SqliteConnection(connectionString);
        
        connection.Open();
        var command = connection.CreateCommand();
        command.Connection = connection;
        command.CommandText = migrate;
        command.ExecuteNonQuery();
        connection.Close();

        return connectionString;
    }
}