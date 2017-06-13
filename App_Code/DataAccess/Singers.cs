using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Singers
/// </summary>
public class Singers
{
	public Singers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string singerId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public bool gender { get; set; }
    public DateTime dateOfBirth { get; set; }
    public Groups groupId { get; set; }
    public Nationalities nationalityId { get; set; }
}