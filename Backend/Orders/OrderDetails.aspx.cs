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
          
            OrderDetailsDao dao = new OrderDetailsDao();
            string orderId = Request.QueryString["orderId"];         
            List<OrderDetails> list = dao.FindAll(Convert.ToInt32(orderId));
            Repeater.DataSource = list;
            Repeater.DataBind();
            OrderDao odao = new OrderDao();
            Orders order = odao.SearchId((Convert.ToInt32(orderId)));
            lblOrderId.Text = order.orderId.ToString();
            lblOrderDate.Text = order.orderDate.ToString();
            lblCustomer.Text = order.customerEmail.email;
            lblNote.Text = order.note;
            lblReceivedDate.Text = order.receivedDate.ToString();
            lblShipmentId.Text = order.shipmentId.email;
            lblTotalAmount.Text = order.totalAmount.ToString();
            lblStaff.Text = order.employeeEmail.email;
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}