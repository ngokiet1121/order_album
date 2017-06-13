using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Groups
/// </summary>
public class Groups
{
	public Groups()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int groupId { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public int type { get; set; }
    public string description { get; set; }

}