using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Nationalities_Addnew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            NationalityDao dao = new NationalityDao();
            Nationalities nation = new Nationalities 
            {
                nationalityId = txtId.Text,
                name = txtName.Text
            };
            if (dao.Insert(nation))
            {
                //lblMessageSuccess.Text = "The nationality has been inserted";
                Response.Redirect("ListNationality.aspx");
            }
            else
            {
                lblMessage.Text = "No nationality has been inserted";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}