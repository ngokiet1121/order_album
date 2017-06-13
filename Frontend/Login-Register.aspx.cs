using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Login_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            CollectionDao dao = new CollectionDao();
            string md5 = Help.md5(txtPassword.Text);

            if (dao.checkCusLogin(txtEmail.Text, md5))
            {
                Session["user"] = txtEmail.Text;
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMessage.Text = "Email or Password Incorrect ";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}