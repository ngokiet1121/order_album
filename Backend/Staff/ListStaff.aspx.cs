using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Staff_ListStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CheckStaff();
            BindData();
        }
    }


    public void CheckStaff() 
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            Employees emp = dao.FindId(Session["staff"].ToString());
            if (!(emp.role == 1)) 
            {
                Response.Redirect("http://localhost:1962/Backend/Staff/404Error.html");
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }

    public void BindData()
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            List<Employees> list = dao.FindAll();
            Repeater.DataSource = list;
            Repeater.DataBind();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void LinkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            EmployeesDao dao = new EmployeesDao();
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument;
            dao.DeleteData(id);
            BindData();
            lblmessage.Text = "Staff has been deleted";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}