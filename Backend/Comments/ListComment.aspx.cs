using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Comments_ListComment : System.Web.UI.Page
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
            CommentDao dao = new CommentDao();
            List<Comments> list = dao.FindAll();
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
            CommentDao dao = new CommentDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            dao.DeleteData(id);
            BindData();
            lblmessage.Text = "An banner has been delete";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}