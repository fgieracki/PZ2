namespace lab04;

public class Order
{
    public String orderid { get; set; }
    public String customerid { get; set; }
    public String employeeid { get; set; }
    public String orderdate { get; set; }
    public String requireddate { get; set; }
    public String shippeddate { get; set; }
    public String shipvia { get; set; }
    public String freight { get; set; }
    public String shipname { get; set; }
    public String shipaddress { get; set; }
    public String shipcity { get; set; }
    public String shipregion { get; set; }
    public String shippostalcode { get; set; }
    public String shipcountry { get; set; }
    
    public static Order FromCsv(String csvLine)
    {
        String[] values = csvLine.Split(',');
        Order order = new Order();
        order.orderid = values[0];
        order.customerid = values[1];
        order.employeeid = values[2];
        order.orderdate = values[3];
        order.requireddate = values[4];
        order.shippeddate = values[5];
        order.shipvia = values[6];
        order.freight = values[7];
        order.shipname = values[8];
        order.shipaddress = values[9];
        order.shipcity = values[10];
        order.shipregion = values[11];
        order.shippostalcode = values[12];
        order.shipcountry = values[13];
        return order;
    }
    
    public override String ToString()
    {
        return $"Order ID: {orderid}, " +
               $"Customer ID: {customerid}, " +
               $"Employee ID: {employeeid}, " +
               $"Order Date: {orderdate}, " +
               $"Required Date: {requireddate}, " +
               $"Shipped Date: {shippeddate}, " +
               $"Ship Via: {shipvia}, " +
               $"Freight: {freight}, " +
               $"Ship Name: {shipname}, " +
               $"Ship Address: {shipaddress}, " +
               $"Ship City: {shipcity}, " +
               $"Ship Region: {shipregion}, " +
               $"Ship Postal Code: {shippostalcode}, " +
               $"Ship Country: {shipcountry}";
    }
}