namespace lab04;

public class Employee
{
    public String employeeid { get; set; }
    public String lastname { get; set; }
    public String firstname { get; set; }
    public String title { get; set; }
    public String titleofcourtesy { get; set; }
    public String birthdate { get; set; }
    public String hiredate { get; set; }
    public String address { get; set; }
    public String city { get; set; }
    public String region { get; set; }
    public String postalcode { get; set; }
    public String country { get; set; }
    public String homephone { get; set; }
    public String extension { get; set; }
    public String photo { get; set; }
    public String notes { get; set; }
    public String reportsTo { get; set; }
    public String photoPath { get; set; }
    
    public static Employee FromCsv(String csvLine)
    {
        String[] values = csvLine.Split(',');
        Employee employee = new Employee();
        employee.employeeid = values[0];
        employee.lastname = values[1];
        employee.firstname = values[2];
        employee.title = values[3];
        employee.titleofcourtesy = values[4];
        employee.birthdate = values[5];
        employee.hiredate = values[6];
        employee.address = values[7];
        employee.city = values[8];
        employee.region = values[9];
        employee.postalcode = values[10];
        employee.country = values[11];
        employee.homephone = values[12];
        employee.extension = values[13];
        employee.photo = values[14];
        employee.notes = values[15];
        employee.reportsTo = values[16];
        employee.photoPath = values[17];
        return employee;
    }

    public override String ToString()
    {
        return $"Employee ID: {employeeid}, " +
               $"Last Name: {lastname}, " +
               $"First Name: {firstname}, " +
               $"Title: {title}, " +
               $"Title of Courtesy: {titleofcourtesy}, " +
               $"Birth Date: {birthdate}, " +
               $"Hire Date: {hiredate}, " +
               $"Address: {address}, " +
               $"City: {city}, " +
               $"Region: {region}, " +
               $"Postal Code: {postalcode}, " +
               $"Country: {country}, " +
               $"Home Phone: {homephone}, " +
               $"Extension: {extension}, " +
               $"Photo: {photo}, " +
               $"Notes: {notes}, " +
               $"Reports To: " +
               $"{reportsTo}, " +
               $"Photo Path: {photoPath}";
    }
}