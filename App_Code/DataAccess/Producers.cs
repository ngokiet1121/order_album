using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Producers
/// </summary>
public class Producers
{
	public Producers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int producerId { get; set; }
    public string name { get; set; }
    public List<Albums> albums { get; set; }
}