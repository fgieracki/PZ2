namespace lab04;

public class Territory
{
    public String territoryid { get; set; }
    public String territorydescription { get; set; }
    public String regionid { get; set; }
    
    public static Territory FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        Territory territory = new Territory();
        territory.territoryid = values[0];
        territory.territorydescription = values[1];
        territory.regionid = values[2];
        return territory;
    }
    
    
    public override string ToString()
    {
        return $"Territory ID: {territoryid}, Territory Description: {territorydescription}, Region ID: {regionid}";
    }
}