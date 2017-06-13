using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Shipments
/// </summary>
public class Shipments
{
	public Shipments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int shipmentId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string address { get; set; }

}