namespace lab05;

public class Producer
{
    public int id;
    public bool stopped;
    public int ProducedDataCount;
    public Random random;
    public List<Data> dataList;


    public Producer(int id, List<Data> dataList)
    {
        this.id = id;
        this.dataList = dataList;
        this.stopped = false;
        this.ProducedDataCount = 0;
        this.random = new Random();
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Run()
    {
        while (!stopped)
        {
            int dataId = random.Next(0, 100);
            Data data = new Data();
            data.ProducerId = id;
            data.DataId = dataId;
            
            lock (dataList)
            {
                dataList.Add(data);
            }
            ProducedDataCount++;
            Thread.Sleep(random.Next(1000, 3000));
        }
    }
    
}