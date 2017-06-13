using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Albums
/// </summary>
public class Albums
{
	public Albums()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int albumId { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public Producers producerId { get; set; }
    public double unitPrice { get; set; }
    public int status { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public DateTime publishedDate { get; set; }
    public DateTime enteredDate { get; set; }
    public float rate { get; set; }
    public string tags { get; set; }

}