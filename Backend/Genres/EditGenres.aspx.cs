using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Genres_EditGenres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GenresDao dao = new GenresDao();
                string id = Request.QueryString["id"];
                Genres genres = dao.SearchId(Convert.ToInt32(id));
                txtName.Text = genres.name;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            GenresDao dao = new GenresDao();
            string id = Request.QueryString["id"];
            Genres genres = new Genres
            {
                genresId = Convert.ToInt32(id),
                name = txtName.Text
            };
            if (dao.Update(genres))
            {
              //  lblMessageSuccess.Text = "The genre has been updated";
                Response.Redirect("ListGenres.aspx");
            }
            else
            {
                lblMessage.Text = "No genre has been updated";
            }
        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
        }
    }
}