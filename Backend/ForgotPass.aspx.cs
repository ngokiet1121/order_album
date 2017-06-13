using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnForgot_Click(object sender, EventArgs e)
    {
        try
        {
            string password = Help.GetRandomString();
            string md5 = Help.md5(password);
            CollectionDao dao = new CollectionDao();
            if (dao.ChangePass(txtEmail.Text,md5))
            {
                dao.SendEmail(txtEmail.Text, "Change Pass Success", "Your New Pass id \n" + password);
                lblMessageSuccess.Text = "Change success and send mail";
            }
            else 
            {
                lblMessage.Text = "Error change";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}