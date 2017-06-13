using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService {

    public AutoComplete () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        {
            string sql = "select Name from Albums where Name like @Name";
            using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    List<string> list = new List<string>();
                    cmd.Parameters.AddWithValue("Name", prefixText+"%");
                    SqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(reader.GetOrdinal("Name")));
                        if (i > count)
                            break;
                    }

                    reader.Close();
                    return list.ToArray<string>();
                }
            }
        }

    }
    
}
