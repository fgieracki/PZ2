namespace lab04;

public class App
{
    static List<Territory> territories = new();
    static List<Region> regions = new();
    static List<Employee> employees = new();
    static List<EmployeeTerritory> employeeTerritories = new();
    static List<Order> orders = new();
    static List<OrderDetails> orderDetails = new();


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
        orders = ReadData("../../../data/orders.csv", Order.FromCsv);
        orderDetails = ReadData("../../../data/orders_details.csv", OrderDetails.FromCsv);
        
        printData();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    public static void Task2()
    {
        Console.WriteLine("Task 2");
        var result = from employee in employees
            select employee.lastname;
        foreach(var record in result.ToList())
        {
            Console.WriteLine(record.ToString());
        }
    }

    public static void Task3()
    {
        Console.WriteLine("Task 3");

        var result = from employee in employees
            join employeeTerritory in employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
            join territory in territories on employeeTerritory.territoryid equals territory.territoryid
            join region in regions on territory.regionid equals region.regionid
            select new {employee.lastname, region.regiondescription, territory.territorydescription};
        
        foreach(var record in result.ToList())
            Console.WriteLine(record.ToString());
    }

    public static void Task4()
    {
        Console.WriteLine("Task 4");

        var result = from employee in employees
                join employeeTerritory in employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
                join territory in territories on employeeTerritory.territoryid equals territory.territoryid
                join region in regions on territory.regionid equals region.regionid
                group employee by region.regiondescription
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
        Console.WriteLine("Task 5");
        var result = from employee in employees
            join employeeTerritory in employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
            join territory in territories on employeeTerritory.territoryid equals territory.territoryid
            join region in regions on territory.regionid equals region.regionid
            group employee by region.regiondescription
            into g
            select new { Region = g.Key, Employees = g.ToList().Count };
        foreach (var record in result.ToList())
        {
            Console.WriteLine($"Region: {record.Region}, Employees: {record.Employees}");
        }
    }

    public static void Task6()
    {
        //get employee last name, amount of made orders, average cost of the order (UnitPrice * Quantity * (1 - discount)) and maximum order value joining order details
        Console.WriteLine("Task 6");
        var result = from employee in employees
            join order in orders on employee.employeeid equals order.employeeid
            join orderDetails in orderDetails on order.orderid equals orderDetails.orderid
            group orderDetails by employee.lastname
            into g
            select new {Employee = g.Key, 
                Orders = g.ToList().Count, 
                AverageCost = g.ToList()
                    .Average(x => float.Parse(x.unitprice) * int.Parse(x.quantity) * (1 - double.Parse(x.discount))), 
                MaxCost = g.ToList()
                    .Max(x => float.Parse(x.unitprice) * int.Parse(x.quantity) * (1 - double.Parse(x.discount)))};

        foreach (var record in result.ToList())
        {
            Console.WriteLine($"Employee: {record.Employee}, " +
                              $"Count: {record.Orders.ToString()}, Average: {record.AverageCost.ToString()}, " +
                              $"Max: {record.MaxCost.ToString()}");
        }


    }

    public static void printData()
    {
        foreach(var employee in employees)
            Console.WriteLine(employee.ToString());
    }

}