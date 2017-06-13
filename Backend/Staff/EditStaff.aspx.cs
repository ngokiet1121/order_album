using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Staff_EditStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                EmployeesDao dao = new EmployeesDao();
                string id = Request.QueryString["id"];
                Employees emp = dao.FindId(id);
                txtEmail.Text = emp.email;
                txtName.Text = emp.fullName;
                txtPhone.Text = emp.phone;
                txtDOB.Text = emp.dateOfBirth.ToString();
                ddlGender.SelectedValue = emp.gender.ToString();
                txtAddress.Text = emp.address;
                ddlRole.SelectedValue = emp.role.ToString();
                ddlStatus.SelectedValue = emp.status.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            Employees emp = new Employees
            {
                email = txtEmail.Text,
                fullName = txtName.Text,
                phone = txtPhone.Text,
                dateOfBirth = Convert.ToDateTime(txtDOB.Text),
                address = txtAddress.Text,
                gender = Convert.ToBoolean(ddlGender.SelectedValue),
                role = Convert.ToInt32(ddlRole.SelectedValue),
                status = Convert.ToInt32(ddlStatus.SelectedValue)
            };
            if (dao.UpdateStaff(emp))
            {
                //lblMessageSuccess.Text = "Edit Employee Successfully";
                Response.Redirect("ListStaff.aspx");
            }
            else
            {
                lblMessage.Text = "Error Add";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}