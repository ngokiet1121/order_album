using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetails
/// </summary>
public class OrderDetails
{
	public OrderDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Orders orderId { get; set; }
    public Albums albumId { get; set; }
    public string image { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public double unitprice { get; set; }
    public CodeSales codeId { get; set; }
    public float tax { get; set; }
    public float shippingFee { get; set; }
    public string note { get; set; }
    public double TotalPrice
    {
        get
        {
            return quantity * unitprice;
        }
        set { TotalPrice = value; }
    }
    public double Subtotal 
    {
        get { return TotalPrice += TotalPrice; }
        set { Subtotal = value; }
    }
}