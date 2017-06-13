using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_ChangPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            Employees emp = dao.FindId(Session["staff"].ToString());
            if (Help.md5(txtPass.Text).Equals(emp.password))
            {
                if (txtNewPass.Text != null && txtNewPass.Text.Equals(txtComfirmPass.Text))
                {
                    CollectionDao colleDao = new CollectionDao();
                    colleDao.ChangePass(Session["staff"].ToString(), Help.md5(txtNewPass.Text));
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
                else 
                {
                    lblMessage.Text = "Error Error Error";
                }
            }
            else 
            {
                lblMessage.Text = "Error Old Pass";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}