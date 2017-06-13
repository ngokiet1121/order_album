using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
	public Orders()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int orderId { get; set; }
    public int status { get; set; }
    public Customers customerEmail { get; set; }
    public DateTime orderDate { get; set; }
    public double totalAmount { get; set; }
    public string note { get; set; }
    public Employees employeeEmail { get; set; }
    public DateTime receivedDate { get; set; }
    public Shipments shipmentId { get; set; }
}