namespace lab04;

public class App
{
    private static List<Territory> _territories = new();
    private static List<Region> _regions = new();
    private static List<Employee> _employees = new();
    private static List<EmployeeTerritory> _employeeTerritories = new();
    private static List<Order> _orders = new();
    private static List<OrderDetails> _orderDetails = new();


    public static List<T> ReadData<T> (String path, Func<String, T> fromCsv)
    {
        List<T> result = File.ReadAllLines(path)
            .Skip(1)
            .Select(fromCsv)
            .ToList();
        
        Console.WriteLine(result.Count);
        return result;
    }
    
    public static void Main()
    {
        _territories = ReadData("../../../data/territories.csv", Territory.FromCsv);
        _regions = ReadData("../../../data/regions.csv", Region.FromCsv);
        _employees = ReadData("../../../data/employees.csv", Employee.FromCsv);
        _employeeTerritories = ReadData("../../../data/employee_territories.csv", EmployeeTerritory.FromCsv);
        _orders = ReadData("../../../data/orders.csv", Order.FromCsv);
        _orderDetails = ReadData("../../../data/orders_details.csv", OrderDetails.FromCsv);
        
        PrintData();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    private static void Task2()
    {
        Console.WriteLine("Task 2");
        var result = from employee in _employees
            select employee.lastname;
        foreach(var record in result.ToList())
        {
            Console.WriteLine(record);
        }
    }

    private static void Task3()
    {
        Console.WriteLine("Task 3");

        var result = from employee in _employees
            join employeeTerritory in _employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
            join territory in _territories on employeeTerritory.territoryid equals territory.territoryid
            join region in _regions on territory.regionid equals region.regionid
            select new {employee.lastname, region.regiondescription, territory.territorydescription};
        
        foreach(var record in result.ToList())
            Console.WriteLine(record.ToString());
    }

    private static void Task4()
    {
        Console.WriteLine("Task 4");

        var result = from employee in _employees
                join employeeTerritory in _employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
                join territory in _territories on employeeTerritory.territoryid equals territory.territoryid
                join region in _regions on territory.regionid equals region.regionid
                group employee by region.regiondescription
                into g
                select new { Region = g.Key, Employees = g.ToHashSet() };
            
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
    
    private static void Task5()
    {
        Console.WriteLine("Task 5");
        var result = from employee in _employees
            join employeeTerritory in _employeeTerritories on employee.employeeid equals employeeTerritory.employeeid
            join territory in _territories on employeeTerritory.territoryid equals territory.territoryid
            join region in _regions on territory.regionid equals region.regionid
            group employee by region.regiondescription
            into g
            select new { Region = g.Key, Employees = g.ToList().Count };
        foreach (var record in result.ToList())
        {
            Console.WriteLine($"Region: {record.Region}, Employees: {record.Employees}");
        }
    }

    private static void Task6()
    {
        //get employee last name, amount of made orders, average cost of the order (UnitPrice * Quantity * (1 - discount)) and maximum order value joining order details
        Console.WriteLine("Task 6");
        var result = from employee in _employees
            join order in _orders on employee.employeeid equals order.employeeid
            join orderDetails in _orderDetails on order.orderid equals orderDetails.orderid
            group orderDetails by employee.lastname
            into g
            select new {Employee = g.Key, 
                Orders = g.ToList().Count, 
                AverageCost = g.ToList()
                    .Average(x => x.unitprice * x.quantity * (1 - x.discount)), 
                MaxCost = g.ToList()
                    .Max(x => x.unitprice * x.quantity * (1 - x.discount))};
        
        foreach (var record in result.ToList())
        {
            Console.WriteLine($"Employee: {record.Employee}, " +
                              $"Count: {record.Orders.ToString()}, Average: {String.Format("{0:0.00}", record.AverageCost)}, " +
                              $"Max: {String.Format("{0:0.00}", record.MaxCost)}");
        }


    }

    private static void PrintData()
    {
        // foreach(var orderDetail in orderDetails)
        //     Console.WriteLine(orderDetail.ToString());
    }

}