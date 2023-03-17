using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Serialization;

namespace lab03;

public class DataManager
{
    public List<Tweet> _tweets = new();

    public void readData()
    {
        var file = File.ReadAllLines("../../../favorite-tweets.json");
        foreach (var line in file) {
            var tweet = JsonSerializer.Deserialize<Tweet>(line);
            _tweets.Add(tweet);
        }
    }

    public void writeToXML(string input_file, string output_file)
    {

        if (input_file == null && output_file != null)
        {
            TweetDTO tweets = new TweetDTO();
            System.IO.FileStream file = System.IO.File.Create(@"../../../" + output_file);
            
            tweets.tweets = _tweets;
            
            System.Xml.Serialization.XmlSerializer x = 
                new System.Xml.Serialization.XmlSerializer(tweets.GetType());
            x.Serialize(file, tweets);
            file.Close();
        }
        else if(output_file == null && input_file != null)
        {
            TweetDTO objectToDeserialize = new TweetDTO();
            TweetDTO tweetDTO = new TweetDTO();
            XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(objectToDeserialize.GetType());

            using(StreamReader streamReader = new StreamReader(@"../../../" + input_file)) 
            { 
                 tweetDTO = (TweetDTO)xmlserializer.Deserialize(streamReader); 
            }
            Console.WriteLine(objectToDeserialize.tweets.Count());
            
            _tweets = new List<Tweet>();
            foreach(var tweet in tweetDTO.tweets)
            {
                _tweets.Add(tweet);
            }
        }
    }
    
    public List<Tweet> sortByUserNameAndCreatedAt()
    {
        return _tweets
            .OrderBy(tweet => tweet.UserName)
            .ThenBy(tweet => DateTime.Parse(
                tweet.CreatedAt.Replace("at", ""))
            ).ToList();
    }

    public List<Tweet> sortByUserName()
    {
        return _tweets
            .OrderBy(tweet => tweet.UserName).ToList();
    }

    public List<Tweet> sortByCreatedAt()
    {
        return _tweets
            .OrderBy(tweet => DateTime
                .Parse(tweet.CreatedAt
                    .Replace("at", "")))
            .ToList();
    }
    
    public Tweet getLatestTweet()
    {
        return _tweets
            .OrderBy(tweet => DateTime.Parse(
                tweet.CreatedAt.Replace("at", ""))
            ).Last();
    }
    
    public Tweet getEarliestTweet()
    {
        return _tweets
            .OrderBy(tweet => DateTime.Parse(
                tweet.CreatedAt.Replace("at", ""))
            ).First();
    }
    
    public Dictionary<string, List<Tweet>> groupByUserName()
    {
        return _tweets
            .GroupBy(tweet => tweet.UserName)
            .ToDictionary(group => group.Key, group => group.ToList());
    }
    
    public Dictionary<string, int> countWordsInTweets()
    {
        var words = new Dictionary<string, int>();
        foreach(var tweet in _tweets)
        {
            var text = tweet.Text;
            var wordsInTweet = text.Split(" ");
            foreach(var word in wordsInTweet)
            {
                if(word.Trim() == "") continue;
                if(words.ContainsKey(word))
                {
                    words[word]++;
                }
                else
                {
                    words.Add(word, 1);
                }
            }
        }
        return words;
    }

    public void print10MostPopularWords(Dictionary<string, int> wordBank)
    {
        var sortedWords = wordBank
            .Where(key => key.Key.Length >= 5)
            .OrderByDescending(word => word.Value)
            .Take(10);

        foreach (var word in sortedWords)
        {
            Console.WriteLine(word.Key + " " + word.Value);       
        }
    }

    public void printTOP10IDF()
    {
        Dictionary<string, HashSet<int>> wordToTweetID = new();
        var tweets = _tweets;

        for (int i = 0; i < tweets.Count; i++)
        {
            var tweet = tweets[i];
            var text = tweet.Text;
            var wordsInTweet = text.Split(" ");
            foreach (var word in wordsInTweet)
            {
                if (word.Trim() == "") continue;
                if (wordToTweetID.ContainsKey(word))
                {
                    wordToTweetID[word].Add(i);
                }
                else
                {
                    wordToTweetID.Add(word, new HashSet<int>() { i });
                }
            }
        }

        var sortedWords = wordToTweetID
            .Select(tweet => 
                new KeyValuePair<string, double>(tweet.Key, Math.Log((double)tweets.Count / tweet.Value.Count)))
            .OrderByDescending(word => word.Value)
            .Take(10);

        foreach (var word in sortedWords)
        {
            Console.WriteLine(word.Key + " " + word.Value);
        }
    }
}