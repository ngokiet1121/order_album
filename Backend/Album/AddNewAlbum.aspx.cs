using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Album_AddNewAlbum : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindDataProducer();
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
        try
        {
            AlbumDao dao = new AlbumDao();
            Albums album = new Albums
            {
                name = txtName.Text,
                quantity = Convert.ToInt32(txtQuantity.Text),
                producerId = new Producers 
                {
                    producerId = Convert.ToInt32(ddlProducer.SelectedValue),
                },
                unitPrice = Convert.ToDouble(txtUnitAlbum.Text),
                status = Convert.ToInt32(ddlStatus.SelectedValue),
                description = textareaDescription.Text,
                image = "../../Images/Album/" + txtFileUpLoad.FileName,
                publishedDate = Convert.ToDateTime(txtPublishedDate.Text),
                enteredDate = Convert.ToDateTime(txtEnteredDate.Text),
                rate = 1,
                tags = ddlTags.SelectedValue
            };

                //string src = "~/Images/Album/" + fileName;
                //img = new Images(fileName, brief, src, product);
                //imgDao.Insert(img);

            if (dao.Insert(album))
            {
               // lblMessageSuccess.Text = "+ 1 Album";
                string fileName = Path.GetFileName(txtFileUpLoad.FileName);
                txtFileUpLoad.SaveAs(Server.MapPath("~/Images/Album/") + fileName);
                Response.Redirect("ListAlbum.aspx");
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