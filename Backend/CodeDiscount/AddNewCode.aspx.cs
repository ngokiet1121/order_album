using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_CodeDiscount_AddNewCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            CodeSaleDao dao = new CodeSaleDao();
            CodeSales codeSale = new CodeSales 
            {
                beginDate = Convert.ToDateTime(txtDateBegin.Text),
                endDate = Convert.ToDateTime(txtDateEnd.Text),
                percentSales = Convert.ToInt32(txtPercent.Text),               
                status = Convert.ToInt32(ddlStatus.SelectedValue),
                code = txtCode.Text
            };
            if (dao.Insert(codeSale))
            {
                //lblMessageSuccess.Text = "New code sale has been inserted";
                Response.Redirect("ListCodeDiscount.aspx");
            }
            else
            {
                lblMessage.Text = "Error Add New";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}