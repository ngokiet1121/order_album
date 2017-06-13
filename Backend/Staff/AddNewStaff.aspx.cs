using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Staff_AddNewStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            if (txtEmail.Text.Equals("")) 
            {
                lblMessage.Text = "Email is Null";
                txtEmail.Focus();
            }
            Employees emp = new Employees
            {
                email = txtEmail.Text,
                fullName = txtName.Text,
                password = txtPassword.Text,
                phone = txtPhone.Text,
                dateOfBirth = Convert.ToDateTime(txtDOB.Text),
                address = txtAddress.Text,
                gender = Convert.ToBoolean(ddlGender.SelectedValue),
                role = Convert.ToInt32(ddlRole.SelectedValue),
                status = Convert.ToInt32(ddlStatus.SelectedValue)
            };
            if (dao.Insert(emp)){
            //lblMessageSuccess.Text = "Add Success";
                Response.Redirect("ListStaff.aspx");
            }            
            else
            {
                lblMessage.Text = "Error Add";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    
}