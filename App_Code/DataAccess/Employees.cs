using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employees
/// </summary>
public class Employees
{
	public Employees()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string email { get; set; }
    public string fullName { get; set; }
    public string password { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public bool gender { get; set; }
    public int status { get; set; }
    public int role { get; set; }
}