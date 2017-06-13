using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Groups_AddGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            GroupDao dao = new GroupDao();
            Groups group = new Groups
            {
                name = txtName.Text,
                type = Convert.ToInt32(ddlType.SelectedValue),
                description = txtDescription.Text,
                image = txtFileUpLoad.FileName
            };
            if (dao.Insert(group))
            {
               // lblMessageSuccess.Text = "Add new group successfully";
                string fileName = Path.GetFileName(txtFileUpLoad.FileName);
                txtFileUpLoad.SaveAs(Server.MapPath("~/Images/Group/") + fileName);
                Response.Redirect("ListGroup.aspx");
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