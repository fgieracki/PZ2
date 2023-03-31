namespace Task3;

public class DirectorySearcher
{
    public void SearchDirectory(string directory, string subString, Queue<String> queue)
    {
        try
        {
            foreach (string fileName in Directory.GetFiles(directory))
            {
                if (fileName.Contains(subString))
                {
                    // Console.WriteLine(fileName);
                    queue.Enqueue(fileName);
                }
            }
            
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                SearchDirectory(subDirectory, subString, queue);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied to: " + directory);
        }
    }
    
}