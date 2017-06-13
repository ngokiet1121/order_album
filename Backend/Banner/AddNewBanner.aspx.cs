using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Banner_AddNewBanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindDataGroup();
        }
    }
    public void BindDataGroup()
    {
        try
        {
            GroupDao groupdao = new GroupDao();
            List<Groups> list = groupdao.FindAll();
            ddlGroup.DataSource = list;
            ddlGroup.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            BannerGroupDao dao = new BannerGroupDao();
            BannerGroups banner = new BannerGroups
            {
                image = txtFileUpLoad.FileName,
                groupId = new Groups {
                    groupId = Convert.ToInt32(ddlGroup.SelectedValue)
                }
            };

            if (dao.Insert(banner))
            {
                //lblMessageSuccess.Text = "Add new banner successfully";
                Response.Redirect("ListBanner.aspx");
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