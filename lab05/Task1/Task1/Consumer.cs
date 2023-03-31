namespace lab05;

public class Consumer
{
    public int id;
    public bool stopped;
    public int ConsumedDataCountTotal;
    public Dictionary<int, int> ConsumedDataCountByProducer;
    public Random random;
    public List<Data> dataList;
    
    public Consumer(int id, List<Data> dataList)
    {
        this.id = id;
        this.dataList = dataList;
        this.stopped = false;
        this.ConsumedDataCountTotal = 0;
        this.ConsumedDataCountByProducer = new Dictionary<int, int>();
        this.random = new Random();
    }
    
    public void Stop()
    {
        stopped = true;
        
        
    }

    public void run()
    {
        while (!stopped)
        {
            lock (dataList)
            {
                if (dataList.Count > 0)
                {
                    Data data = dataList[0];
                    dataList.RemoveAt(0);
                    if (ConsumedDataCountByProducer.ContainsKey(data.ProducerId))
                    {
                        ConsumedDataCountByProducer[data.ProducerId]++;
                    }
                    else
                    {
                        ConsumedDataCountByProducer.Add(data.ProducerId, 1);
                    }
                    ConsumedDataCountTotal++;
                }
            }
            Thread.Sleep(random.Next(1000, 3000));
        }
        
        Console.WriteLine("Consumer {0} consumed {1} items in total", id.ToString(), ConsumedDataCountTotal.ToString());
        foreach (KeyValuePair<int, int> entry in ConsumedDataCountByProducer)
        {
            Console.WriteLine("Consumer {0} consumed {1} items from producer {2}", id.ToString(), entry.Value.ToString(), entry.Key.ToString());
        }
        Console.WriteLine("========================================");
    }
}