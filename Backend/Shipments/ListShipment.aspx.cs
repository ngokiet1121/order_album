using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Shipments_ListShipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            BindData();
        }
    }
    public void BindData()
    {
        try
        {
            ShipmentDao dao = new ShipmentDao();
            Repeater.DataSource = dao.FindAll();
            Repeater.DataBind();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ShipmentDao dao = new ShipmentDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            dao.DeleteData(id);
            BindData();
            lblmessage.Text = "Shipment has been deleted";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}