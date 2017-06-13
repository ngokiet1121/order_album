using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Messages_Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                MessageDao dao = new MessageDao();
                List<Messages> list = dao.FindAllStatus1();
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
    }
}