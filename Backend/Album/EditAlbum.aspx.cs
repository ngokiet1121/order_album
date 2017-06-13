using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Album_EditAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindDataProducer();
            try
            {
                AlbumDao dao = new AlbumDao();
                string id = Request.QueryString["id"];
                Albums album = dao.SearchId(Convert.ToInt32(id));
                txtName.Text = album.name;
                txtQuantity.Text = album.quantity.ToString();
                txtUnitAlbum.Text = album.unitPrice.ToString();
                txtPublishedDate.Text = album.publishedDate.ToString();
                txtEnteredDate.Text = album.enteredDate.ToString();
                ddlStatus.SelectedValue = album.status.ToString();
                ddlProducer.SelectedValue = album.producerId.producerId.ToString();              
                ddlTags.SelectedValue = album.tags;
                textareaDescription.Text = album.description;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }
    }
    public void BindDataProducer()
    {
        try
        {
            ProducerDao dao = new ProducerDao();
            List<Producers> list = dao.FindAll();
            ddlProducer.DataSource = list;
            ddlProducer.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewAlbum.aspx");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            string id = Request.QueryString["id"];
            Albums album = new Albums
            {
                albumId = Convert.ToInt32(id),
                name = txtName.Text,
                quantity = Convert.ToInt32(txtQuantity.Text),
                producerId = new Producers
                {
                    producerId = Convert.ToInt32(ddlProducer.SelectedValue),
                },
                unitPrice = Convert.ToDouble(txtUnitAlbum.Text),
                status = Convert.ToInt32(ddlStatus.SelectedValue),
                description = textareaDescription.Text,
                image = "../../Images/Album/"+txtFileUpLoad.FileName,
                publishedDate = Convert.ToDateTime(txtPublishedDate.Text),
                enteredDate = Convert.ToDateTime(txtEnteredDate.Text),
                rate = 1,
                tags = ddlTags.SelectedValue
            };
            if (dao.Update(album))
            {
                //lblMessageSuccess.Text = "Edit Success";
                string fileName = Path.GetFileName(txtFileUpLoad.FileName);
                txtFileUpLoad.SaveAs(Server.MapPath("~/Images/Album/") + fileName);
               
                Response.Redirect("ListAlbum.aspx");
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