using Microsoft.Data.Sqlite;

namespace lab08;

public class App
{
    public static void Main(string[] args)
    {
        var data = DataReader.ReadCSV("E:\\dokumenty\\inne\\AGH\\PZ2\\lab08\\lab08\\data.csv", ',');
        var columnTypes = DataBaseManager.GetColumnTypes(data);

        string tableName = "mytable";
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = "./Lab08db.db";
        
        var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine(DataBaseManager.CreateDatabaseTable(columnTypes, tableName, connection)); 
        Console.WriteLine(DataBaseManager.InsertDataIntoTable(data, tableName, connection, columnTypes));
        
        DataBaseManager.PrintTableData(tableName, connection);

    }
}