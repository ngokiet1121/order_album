using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Orders_ListOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindData();
        }
    }
    public void BindData() 
    {
        try
        {
            OrderDao dao = new OrderDao();
            List<Orders> list = dao.FillAll();
            Repeater.DataSource = list;
            Repeater.DataBind();
            RepeaterStatus.DataSource = list;
            RepeaterStatus.DataBind();         
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }

    protected void lbtnInProgress_Click(object sender, EventArgs e)
    {
        try
        {
            OrderDao dao = new OrderDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Orders order = new Orders
            {
                orderId = id,
                 employeeEmail = new Employees
                {
                    email = Session["staff"].ToString()
                },
                status = 1,
               
            };
            if (dao.Update(order)) 
            {
                Response.Redirect("ListOrders.aspx");
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void lbtnSolved_Click(object sender, EventArgs e)
    {
        try
        {
            OrderDao dao = new OrderDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Orders order = new Orders
            {
                orderId = id,
                 employeeEmail = new Employees {
                    email =  Session["staff"].ToString()
                },
                status = 2,
                
            };
            if (dao.Update(order))
            {
                Response.Redirect("ListOrders.aspx");
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            OrderDao dao = new OrderDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Orders order = new Orders
            {
                orderId = id,
                 employeeEmail = new Employees
                {
                    email = Session["staff"].ToString()
                },
                status = 3,
               
            };
            if (dao.Update(order))
            {
                Response.Redirect("ListOrders.aspx");
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}