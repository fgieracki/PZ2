using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.CompilerServices;

namespace filip.Data;

public class Database
{
    private static SqliteConnection _connection;

    public static void Init()
    {
        _connection = new SqliteConnection(new SqliteConnectionStringBuilder
        {
            DataSource = "./db.db"
        }.ConnectionString);
        _connection.Open();
        Migrate();
    }

    public static void Migrate()
    {
        var hash = MD5Generator.GenerateMD5Hash("admin");
        const string command = @"
CREATE TABLE IF NOT EXISTS users (
email varchar(255),
password varchar(32)
);

CREATE TABLE IF NOT EXISTS records (
id integer primary key,
login varchar(255),
content varchar(255)
);

INSERT INTO users (email, password) VALUES ('admin','21232f297a57a5a743894a0e4a801fc3');
";
        new SqliteCommand(command, _connection).ExecuteNonQuery();
    }

    public static bool TryLogin(string? email, string? password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        var hash = MD5Generator.GenerateMD5Hash(password);
        // var hash = password; //TODO: change me
        var response = new SqliteCommand($"SELECT COUNT(*) FROM users where email='{email}' and password='{hash}'",
                _connection)
            .ExecuteScalar();
        return response != null && (long)response > 0;
    }

    public static List<Record> ListRecords()
    {
        using var command = new SqliteCommand("SELECT * FROM records", _connection);
        using var reader = command.ExecuteReader();
        var records = new List<Record>();
        while (reader.Read())
        {
            records.Add(new Record
            {
                Id = (long)reader.GetValue(0),
                Email = (string)reader.GetValue(1),
                Content = (string)reader.GetValue(2),
            });
        }

        return records;
    }

    public static void Insert(string email, string content)
    {
        new SqliteCommand($"INSERT INTO records (login, content) VALUES ('{email}', '{content}')",
                _connection)
            .ExecuteNonQuery();
    }
}