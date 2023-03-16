// See https://aka.ms/new-console-template for more information

using lab03;

class main
{
    public static void Main(string[] args)
    {
        var dataManager = new DataManager();
        //subtask 1
        dataManager.readData();
        
        //subtask 2
        dataManager.writeToXML();
        
        Console.WriteLine("Subtask 3:");
        var sortedTweets = dataManager.sortByUserNameAndCreatedAt();
        foreach(var tweet in sortedTweets)
        {
            Console.WriteLine(tweet.getUserNameAndDate());
        }
        
        Console.WriteLine("Subtask 4:");
        var latestTweet = dataManager.getLatestTweet();
        Console.WriteLine(latestTweet.getUserNameAndDate());
        
        var earliestTweet = dataManager.getEarliestTweet();
        Console.WriteLine(earliestTweet.getUserNameAndDate());
        
        Console.WriteLine("Subtask 5:");
        var groupedTweets = dataManager.groupByUserName();
        // foreach(var group in groupedTweets)
        // {
        //     Console.WriteLine(group.Key);
        //     foreach(var tweet in group.Value)
        //     {
        //         Console.WriteLine(tweet.getUserNameAndDate());
        //     }
        // }

        Console.WriteLine("Subtask 6:");
        var wordBank = dataManager.countWordsInTweets();
        
        Console.WriteLine("Subtask 7:");
        dataManager.print10MostPopularWords(wordBank);
        
        Console.WriteLine("Subtask 8:");
        dataManager.printTOP10IDF();
        
    }
}