using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Customer_EditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                CustomerDao dao = new CustomerDao();
                string id = Request.QueryString["id"];
                Customers cus = dao.FindCustomer(id);
                txtEmail.Text = cus.email;
                txtAddress.Text = cus.address;
                txtName.Text = cus.fullName;
                txtPhone.Text = cus.phone;
                txtDateOfBirth.Text = cus.dateOfBirth.Day.ToString() + "/" + cus.dateOfBirth.Month.ToString() + "/" + cus.dateOfBirth.Year.ToString();
                txtRegisteredDate.Text = cus.registeredDate.Day.ToString() + "/" + cus.registeredDate.Month.ToString() + "/" + cus.registeredDate.Year.ToString();
                if (cus.gender == true)
                {
                    txtGender.Text = "Male";
                }
                else
                {
                    txtGender.Text = "Female";
                }
                ddlStatus.SelectedValue = cus.status.ToString();
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
            CustomerDao dao = new CustomerDao();
            string id = Request.QueryString["id"];
            Customers cus = new Customers 
            {
                email = id,
                status = Convert.ToInt32(ddlStatus.SelectedValue)
            };
            if (dao.UpdateStatus(cus))
            {
                //lblMessageSuccess.Text = "Update customer successfully";
                Response.Redirect("ViewList.aspx");
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