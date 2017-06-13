using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comments
/// </summary>
public class Comments
{
	public Comments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int commentId { get; set; }
    public Customers customerEmail { get; set; }
    public Albums albumId { get; set; }
    public string comment { get; set; }
    public int status { get; set; }
    public DateTime date { get; set; }
}