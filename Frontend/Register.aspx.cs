using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerDao dao = new CustomerDao();
            Customers cus = new Customers
            {
                email = txtRegisterEmail.Text,
                fullName = txtFullName.Text,
                password = Help.md5(txtRegisterPassword.Text),
                dateOfBirth = Convert.ToDateTime(txtDOB.Text),
                phone = txtPhone.Text,
                address = txtAddress.Text,
                gender = Convert.ToBoolean(ddlGender.SelectedValue),
                status = 1,
                registeredDate = DateTime.Now
            };
            if (dao.Insert(cus))
            {
                Response.Redirect("Login-Register.aspx");
            }
            else
            {
                lblMessage.Text = "Can not register with this email";
            }
        }
        catch(Exception)
        {
            throw;
        }
    }
}