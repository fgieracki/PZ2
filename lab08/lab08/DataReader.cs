namespace lab08;

public class DataReader
{
    public static Dictionary<string, List<string>> ReadCSV(string fileName, char seperator)
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string[] headers = reader.ReadLine()!.Split(seperator);
            foreach (string header in headers)
            {
                List<string> column = new List<string>();
                data.Add(header, column);
            }

            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine()!.Split(seperator);
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] == "")
                        row[i] = "NULL";
                    data[headers[i]].Add(row[i]);
                }
            }
        }
        return data;
    }
}