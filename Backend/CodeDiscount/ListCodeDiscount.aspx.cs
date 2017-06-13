using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_CodeDiscount_ListCodeDiscount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData() 
    {
        try
        {
            CodeSaleDao dao = new CodeSaleDao();
            List<CodeSales> list = dao.FindAll();
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
            CodeSaleDao dao = new CodeSaleDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            dao.DeleteData(id);
            BindData();
            lblmessage.Text = "The banner has been deleted";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}