namespace lab03;

public class TweetDTO
{
    public List<Tweet> tweets { get; set; }
    
    public TweetDTO()
    {
        tweets = new List<Tweet>();
    }
}