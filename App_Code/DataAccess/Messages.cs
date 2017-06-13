using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
	public Messages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int messageId { get; set; }
    public Customers customerEmail { get; set; }
    public string subject { get; set; }
    public string message { get; set; }
    public int status { get; set; }
    public DateTime dateSend { get; set; }
}