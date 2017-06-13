using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            Employees emp = dao.FindId(Session["staff"].ToString());
            txtEmail.Text = emp.email;
            txtName.Text = emp.fullName;
            txtPhone.Text = emp.phone;
            txtAddress.Text = emp.address;
            txtDOB.Text = emp.dateOfBirth.ToString();
            ddlGender.SelectedValue = emp.gender.ToString();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            Employees empl = new Employees 
            {
                email = txtEmail.Text,
                address = txtAddress.Text,
                phone = txtPhone.Text,
                dateOfBirth = Convert.ToDateTime(txtDOB.Text),
                fullName = txtName.Text,
                gender = Convert.ToBoolean(ddlGender.SelectedValue)
            };
            if (dao.Update(empl))
            {
                lblMessageSuccess.Text = "Edit Success";
            }
            else 
            {
                lblMessage.Text = "Error Edit";
            }
           
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}