using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BannerGroups
/// </summary>
public class BannerGroups
{
	public BannerGroups()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int bannerId { get; set; }
    public string image { get; set; }
    public Groups groupId { get; set; }
}