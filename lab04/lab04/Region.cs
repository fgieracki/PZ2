namespace lab04;

public class Region
{
    private String regionid { get; set; }
    private String regiondescription { get; set; }
    
    public static Region FromCsv(String csvLine)
    {
        String[] values = csvLine.Split(',');
        Region region = new Region();
        region.regionid = values[0];
        region.regiondescription = values[1];
        return region;
    }
    
    public override String ToString()
    {
        return $"Region ID: {regionid}, Region Description: {regiondescription}";
    }
}