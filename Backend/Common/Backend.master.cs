using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Common_Backend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("~/Backend/Login.aspx");
            }
            else
            {
                lblName.Text = Session["staff"].ToString();
            }

            BindData();
        }
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Backend/Login.aspx");
    }
    public void BindData()
    {
        try
        {
            MessageDao dao = new MessageDao();
            List<Messages> list = dao.FindAllStatus2();
            lblMail.Text = "You have " + list.Count.ToString() + " messages ";
            lblAllMail.Text = list.Count.ToString();
            Repeater.DataSource = list;
            Repeater.DataBind();
        }
        catch (Exception)
        {
        }
    }
}
