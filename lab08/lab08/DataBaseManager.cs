using Microsoft.Data.Sqlite;

namespace lab08;

public class DataBaseManager
{
    public static Dictionary<string, (string type, bool nullable)> GetColumnTypes(Dictionary<String, List<String>> data)
    {
        var columns = new Dictionary<string, (string type, bool nullable)>();

        foreach (var key in data.Keys)
        {
            if (CheckForInt(data[key]))
            {
                columns.Add(key, ("INTEGER", CheckNulls(data[key])));
            }
            else if (CheckForReal(data[key]))
            {
                columns.Add(key, ("REAL", CheckNulls(data[key])));
            }
            else
            {
                columns.Add(key, ("TEXT", CheckNulls(data[key])));
            }
        }

        return columns;
    }
    
    private static bool CheckNulls(List<string> column)
    {
        foreach (var value in column)
        {
            if (value == "NULL")
            {
                return true;
            }
        }
        return false;
    }
    
    private static bool CheckForReal(List<string> column)
    {
        foreach (var value in column)
        {
            if (value != "NULL" && !double.TryParse(value.Replace('.', ','), out _))
            {
                return false;
            }
        }
        return true;
    }

    private static bool CheckForInt(List<string> column)
    {
        foreach (var value in column)
        {
            if (value != "NULL" && !int.TryParse(value, out _))
            {
                return false;
            }
        }
        return true;
    }

    public static Boolean CreateDatabaseTable(Dictionary<string, (string type, bool nullable)> columnsInfo,
        string tableName, SqliteConnection connection)
    {
        string columnsString = string.Join(", ", columnsInfo.Select(column
            => $"{column.Key} {column.Value.type} {(column.Value.nullable? "NULL" : "NOT NULL")}"));
        
        string sql = $"DROP TABLE IF EXISTS {tableName}; CREATE TABLE {tableName} ({columnsString});";
        
        var command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
        
        return true;
    }

    public static bool InsertDataIntoTable(Dictionary<string, List<string>> data,
        string tableName, SqliteConnection connection, Dictionary<string, (string type, bool nullable)> columnsInfo)
    {
        string[] colNames = data.Keys.ToArray();
        string sql = $"INSERT INTO \"{tableName}\" ({string.Join(", ", colNames)}) VALUES ";

        
        for(int i = 0; i < data.Values.First().Count; i++)
        {
            var rowString = "( ";
            for(int j = 0; j< colNames.Length; j++)
            {
                var key = colNames[j];
                if (data[key][i] == "NULL")
                {
                    rowString += "NULL";
                }
                else if (columnsInfo[key].type == "TEXT")
                {
                    rowString += $"'{data[key][i]}'";
                }
                else
                {
                    rowString += $"{data[key][i]}";
                }

                if (j != colNames.Length - 1)
                {
                    rowString += ", ";
                }
            }

            rowString += "), ";
            // Console.WriteLine(rowString);
            sql += rowString;
        }
        
        sql = sql.Remove(sql.Length - 2, 1);
        sql += ";";
        
        var command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
        return true;
    }

    public static void PrintTableData(string tableName, SqliteConnection connection)
    {
        //Przeglądanie danych przy użyciu data reader                
        var selectCmd = connection.CreateCommand();
        selectCmd.CommandText = $"SELECT * FROM {tableName}";

        using (SqliteDataReader reader = selectCmd.ExecuteReader())
        {
            bool firstRow = true;
            while (reader.Read())
            {
                //pobranie nazw kolumn
                if (firstRow)
                {
                    for (int a = 0; a < reader.FieldCount; a++)
                    {
                        Console.Write(reader.GetName(a));
                        Console.Write("\t");
                    }

                    firstRow = false;
                    Console.WriteLine("");
                }

                //Można pobierać kolumny po ich nazwach
                //Console.Write(reader["Id"] + ",");
                //lub przeiterować po nich w kolejności
                for (int a = 0; a < reader.FieldCount; a++)
                {
                    String? val = null;
                    //jeżeli wartość pola równa się null, to GetString rzuci wyjątkiem,
                    //dlatego przechwytujemy wyjątek
                    try
                    {
                        val = reader.GetString(a);
                    }
                    catch
                    {
                    }

                    Console.Write(val != null ? val : "NULL");
                    Console.Write("\t");
                }

                Console.WriteLine("");
            }

            //readera po zakończeniu pracy należy zamknąć nim będziemy mogli wykonać
            //nowe polecenie na tym samym obiekcie SqliteCommand
            reader.Close();
        }
    }
    

}