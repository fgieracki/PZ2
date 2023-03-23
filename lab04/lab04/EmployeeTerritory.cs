namespace lab04;

public class EmployeeTerritory
{
    public  String employeeid { get; set; }
    public String territoryid { get; set; }
    
    public static EmployeeTerritory FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        EmployeeTerritory employeeTerritory = new EmployeeTerritory();
        employeeTerritory.employeeid = values[0];
        employeeTerritory.territoryid = values[1];
        return employeeTerritory;
    }

    public override string ToString()
    {
        return $"Employee ID: {employeeid}, Territory ID: {territoryid}";
    }
}