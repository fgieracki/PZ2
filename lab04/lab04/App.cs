namespace lab04;

public class App
{
    static List<Territory> territories = new();
    static List<Region> regions = new();
    static List<Employee> employees = new();
    static List<EmployeeTerritory> employeeTerritories = new();


    public static List<T> ReadData<T> (String path, Func<String, T> FromCsv)
    {
        List<T> result = File.ReadAllLines(path)
            .Skip(1)
            .Select(FromCsv)
            .ToList();
        
        Console.WriteLine(result.Count);
        return result;
    }
    
    public static void Main()
    {
        territories = ReadData("../../../data/territories.csv", Territory.FromCsv);
        regions = ReadData("../../../data/regions.csv", Region.FromCsv);
        employees = ReadData("../../../data/employees.csv", Employee.FromCsv);
        employeeTerritories = ReadData("../../../data/employee_territories.csv", EmployeeTerritory.FromCsv);
        
        printData();
        Task2();
        Task3();
        Task4();
        Task5();
    }

    public static void Task2()
    {
        var result = from employee in employees
            select employee.lastname;
        foreach(var record in result.ToList())
        {
            Console.WriteLine(record.ToString());
        }
    }

    public static void Task3()
    {
        var result = from employee in employees
            select new {employee.lastname, employee.region};
        
        foreach(var record in result.ToList())
            Console.WriteLine(record.ToString());
    }

    public static void Task4()
    {
        // get regions from employees and and for each region list of employees
        var result = from employee in employees
            group employee by employee.region
            into g
            select new { Region = g.Key, Employees = g.ToList() };

        foreach (var record in result.ToList())
        {
            String output = "";
            output += $"Region: {record.Region}, Employees: ";
            foreach (var employee in record.Employees)
            {
                output += $"{employee.firstname} {employee.lastname}, ";
            }
            Console.WriteLine(output);
        }
        
    }
    
    public static void Task5()
    {
        // get regions from employees and and for each region count of employees
        var result = from employee in employees
            group employee by employee.region
            into g
            select new { Region = g.Key, Employees = g.ToList().Count };
        foreach (var record in result.ToList())
        {
            Console.WriteLine($"Region: {record.Region}, Employees: {record.Employees}");
        }
        
    }

    public static void printData()
    {
        foreach(var employee in employees)
            Console.WriteLine(employee.ToString());
    }

}