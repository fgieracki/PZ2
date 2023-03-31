using Task3;

class Program
{
    static bool stop = false;
    static void Main(string[] args)
    {
        string directory = @"E:\dokumenty\inne\AGH\PZ2\lab05\Task3\playground";
        string subString = "test";
        Queue<String> queue = new Queue<string>();
        
        if (args.Length == 2)
        {
            directory = args[0];
            subString = args[1];
        }

        DirectorySearcher directorySearcher = new DirectorySearcher();

        Thread searchThread = new Thread(() =>
        {
            directorySearcher.SearchDirectory(directory, subString, queue);
        });
        searchThread.Start();
        searchThread.Join();
        
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }
}