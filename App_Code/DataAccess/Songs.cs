using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Songs
/// </summary>
public class Songs
{
	public Songs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int songId { get; set; }
    public string name { get; set; }
    public Albums albumId { get; set; }
    public Groups groupId { get; set; }
    public Genres genreId { get; set; }
    public string authors { get; set; }
}