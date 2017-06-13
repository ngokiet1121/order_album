using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Singers_ListSingers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            BindData();
        }
    }

    public void BindData()
    {
        try
        {
            SingerDao dao = new SingerDao();
            List<Singers> list = dao.FindAll();
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
            SingerDao dao = new SingerDao();
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument;
            dao.DeleteData(id);
            BindData();
            lblmessage.Text = "Singer has been deleted";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}