// See https://aka.ms/new-console-template for more information

class Program
{
    private static bool stop = false;

    static void Main(string[] args)
    {
        Console.WriteLine("Rozpoczęto monitorowanie zasobów");
        
        string directoryPath = @"E:\dokumenty\inne\AGH\PZ2\lab05\Task2\playground";
        
        FileSystemWatcher watcher = new FileSystemWatcher(directoryPath);
        watcher.IncludeSubdirectories = false;
        
        watcher.EnableRaisingEvents = true;
        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;

        
        Thread inputThread = new Thread(() =>
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Q) ;
            stop = true;
            watcher.Dispose();
        });
        inputThread.Start();
        
        while (!stop)
        {
            Thread.Sleep(1000);
        }
    }
    
    static void OnCreated(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"Dodano plik {e.Name}");
    }
    
    static void OnDeleted(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"Usunięto plik {e.Name}");
    }
}