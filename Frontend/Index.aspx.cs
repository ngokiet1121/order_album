using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Index : System.Web.UI.Page
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
            AlbumDao dao = new AlbumDao();
            List<Albums> list = dao.FindAll();
            RepeaterItem.DataSource = list;
            RepeaterItem.DataBind();
        }
        catch (Exception ex)
        {
            //LblMessage.Text = ex.Message;
        }
    }
   
}