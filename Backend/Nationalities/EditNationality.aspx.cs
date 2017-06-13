using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Nationalities_EditNationality : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                NationalityDao dao = new NationalityDao();
                string id = Request.QueryString["id"];
                Nationalities item = dao.SearchId(id);

                txtId.Text = item.nationalityId;
                txtName.Text = item.name;
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
             NationalityDao dao = new NationalityDao();
             string id = Request.QueryString["id"];
             txtId.Text = id;
             Nationalities nation = new Nationalities 
             {
                nationalityId = txtId.Text,
                name = txtName.Text
             };
             if (dao.Update(nation))
             {
                // lblMessageSuccess.Text = "Nationality has been updated";
                 Response.Redirect("ListNationality.aspx");
             }
             else 
             {
                 lblMessage.Text = "Error Update";
             }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}