namespace lab04;

public class OrderDetails
{
    public String orderid { get; set; }
    public String productid { get; set; }
    public double unitprice { get; set; }
    public double quantity { get; set; }
    public double discount { get; set; }
    
    public static OrderDetails FromCsv(String csvLine)
    {
        String[] values = csvLine.Split(',');
        OrderDetails orderDetails = new OrderDetails();
        orderDetails.orderid = values[0];
        orderDetails.productid = values[1];
        orderDetails.unitprice = double.Parse(values[2].Replace(".", ","));
        orderDetails.quantity = double.Parse(values[3].Replace(".", ","));
        orderDetails.discount = double.Parse(values[4].Replace(".", ","));
        return orderDetails;
    }
    
    public override String ToString()
    {
        return $"Order ID: {orderid}, " +
               $"Product ID: {productid}, " +
               $"Unit Price: {unitprice}, " +
               $"Quantity: {quantity}, " +
               $"Discount: {discount}";
    }
}