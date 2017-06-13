using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Comments_EditComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            BindDataAlbum();
            try
            {
                CommentDao dao = new CommentDao();
                string id = Request.QueryString["id"];
                Comments cmt = dao.SearchId(Convert.ToInt32(id));
                ddlStatus.SelectedValue = cmt.status.ToString();
                txtContent.Text = cmt.comment;
                txtEmail.Text = cmt.customerEmail.email;
                ddlAlbum.SelectedValue = cmt.albumId.albumId.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }

    public void BindDataAlbum()
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            List<Albums> list = dao.FindAll();
            ddlAlbum.DataSource = list;
            ddlAlbum.DataBind();
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
            CommentDao dao = new CommentDao();
            string id = Request.QueryString["id"];
            Comments cmt = new Comments
            {
                commentId = Convert.ToInt32(id),
                customerEmail = new Customers
                {
                    email = txtEmail.Text
                },
                albumId = new Albums
                {
                    albumId = Convert.ToInt32(ddlAlbum.SelectedValue)
                },
                comment = txtContent.Text,
                
                status= Convert.ToInt32(ddlStatus.SelectedValue)
            };
            if (dao.Update(cmt))
            {
                //lblMessageSuccess.Text = "Edit Success";
                Response.Redirect("ListComment.aspx");
            }
            else
            {
                lblMessage.Text = "Error Edit";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}