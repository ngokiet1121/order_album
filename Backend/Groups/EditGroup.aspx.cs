using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Groups_EditGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GroupDao dao = new GroupDao();
                string id = Request.QueryString["id"];
                Groups album = dao.SearchId(Convert.ToInt32(id));
                txtName.Text = album.name;
                ddlType.SelectedValue = album.type.ToString();
                txtDescription.Text = album.description;
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            GroupDao dao = new GroupDao();
            string id = Request.QueryString["id"];
            Groups album = new Groups
            {
                groupId = Convert.ToInt32(id),
                name = txtName.Text,
                type = Convert.ToInt32(ddlType.SelectedValue),
                description = txtDescription.Text,
                image = txtFileUpLoad.FileName
            };
            if (dao.Update(album))
            {
               // lblMessageSuccess.Text = "Edit group successfully";
                string fileName = Path.GetFileName(txtFileUpLoad.FileName);
                txtFileUpLoad.SaveAs(Server.MapPath("~/Images/Group/") + fileName);
                Response.Redirect("ListGroup.aspx");
            }
            else
            {
                lblMessage.Text = "Error Edit";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }
    }
}