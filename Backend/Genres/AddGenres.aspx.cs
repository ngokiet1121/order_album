using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Genres_AddGenres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            GenresDao dao = new GenresDao();
            Genres genres = new Genres
            {
                name = txtName.Text
            };
            if (dao.Insert(genres))
            {
                //lblMessageSuccess.Text = "New genre has been inserted";
                Response.Redirect("ListGenres.aspx");
            }
            else
            {
                lblMessage.Text = "No genre has been inserted";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}