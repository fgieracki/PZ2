namespace lab04;

public class OrderDetails
{
    public String orderid { get; set; }
    public String productid { get; set; }
    public String unitprice { get; set; }
    public String quantity { get; set; }
    public String discount { get; set; }
    
    public static OrderDetails FromCsv(String csvLine)
    {
        String[] values = csvLine.Split(',');
        OrderDetails orderDetails = new OrderDetails();
        orderDetails.orderid = values[0];
        orderDetails.productid = values[1];
        orderDetails.unitprice = values[2];
        orderDetails.quantity = values[3];
        orderDetails.discount = values[4];
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