using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Cart : System.Web.UI.Page
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
            string orderId = Request.QueryString["idorder"];
            List<OrderDetails> list = dao.FindAll(Convert.ToInt32(orderId));
            RepeaterCart.DataSource = list;
            RepeaterCart.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}