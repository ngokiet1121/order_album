using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Banner_EditBanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDataGroup();
            try
            {
                BannerGroupDao dao = new BannerGroupDao();
                string id = Request.QueryString["id"];
                BannerGroups banner = dao.SearchId(Convert.ToInt32(id));
                ddlGroup.SelectedValue = banner.groupId.groupId.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
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
            string id = Request.QueryString["id"];
            BannerGroups banner = new BannerGroups
            {
                bannerId = Convert.ToInt32(id),
                image = txtFileUpLoad.FileName,
                groupId = new Groups 
                {
                    groupId = Convert.ToInt32(ddlGroup.SelectedValue)
                }
            };
            if (dao.Update(banner))
            {
               // lblMessageSuccess.Text = "Edit Successfully";
                Response.Redirect("ListBanner.aspx");
            }
            else
            {
                lblMessage.Text = "Error Edit";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}