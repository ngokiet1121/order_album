using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DataConfig
/// </summary>
public static class DataConfig
{
	public static string ConnectionString = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        
}