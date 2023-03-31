using lab05;

class Program
{
    public static void Main(String[] args)
    {
        int n = 5; //prod
        int m = 5; //cust

        List<Data> dataList = new List<Data>();
        List<Producer> producers = new List<Producer>();
        List<Consumer> consumers = new List<Consumer>();

        for (int i = 0; i < n; i++)
        {
            Producer producer = new Producer(i, dataList);
            producers.Add(producer);
            Thread producerThread = new Thread(producer.Run);
            producerThread.Start();
        }

        for (int i = 0; i < m; i++)
        {
            Consumer consumer = new Consumer(i, dataList);
            consumers.Add(consumer);
            Thread consumerThread = new Thread(consumer.run);
            consumerThread.Start();
        }

        while (Console.ReadKey(true).Key != ConsoleKey.Q);
        foreach (var producer in producers)
        {
            producer.Stop();
        }
        foreach (var consumer in consumers)
        {
            consumer.Stop();
        }
    }
}