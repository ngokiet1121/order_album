using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Rates
/// </summary>
public class Rates
{
	public Rates()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int rateId { get; set; }
    public Albums albumId { get; set; }
    public float rate { get; set; }
}