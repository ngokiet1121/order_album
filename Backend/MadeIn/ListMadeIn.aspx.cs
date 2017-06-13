using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Backend_MadeIn_ListMadeIn : System.Web.UI.Page
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
            ProducerDao dao = new ProducerDao();
            Repeater.DataSource = dao.FindAll();
            Repeater.DataBind();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}