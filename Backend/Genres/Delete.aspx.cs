using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Genres_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                GenresDao dao = new GenresDao();
                string id = Request.QueryString["id"];
                lblMessage.Text = "Id la : " + id;
                dao.DeleteData(Convert.ToInt32(id));
                Response.Redirect("ListGenres.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}