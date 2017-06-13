using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDetail();
            BindComment();
            BindAlbumPre();
            BindAlbumActive();
        }
    }

    public void BindDetail()
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            if (id != null) 
            {
                Albums album = dao.SearchId(Convert.ToInt32(id));
                imgAlbum.ImageUrl = album.image;
                lblAlbumId.Text = album.albumId.ToString();
                lblName.Text = album.name;
                lblProducer.Text = album.producerId.name;
                lblPublisherDate.Text = album.publishedDate.Day.ToString() + "/" + album.publishedDate.Month.ToString() + "/" + album.publishedDate.Year.ToString();
                lblQuantity.Text = album.quantity.ToString();
                lblRate.Text = album.rate.ToString();
                lblUnitPrice.Text = album.unitPrice.ToString();
                txtId.Text = album.albumId.ToString();
                lblDesc.Text = album.description;
            }
            else if (name != null)
            {
                Albums album = dao.SearchByName(name);
                //if (lblAlbumId.Text.Equals(""))
                //{
                imgAlbum.ImageUrl = album.image;
                lblAlbumId.Text = album.albumId.ToString();
                lblName.Text = album.name;
                lblProducer.Text = album.producerId.name;
                lblPublisherDate.Text = album.publishedDate.Day.ToString() + "/" + album.publishedDate.Month.ToString() + "/" + album.publishedDate.Year.ToString();
                lblQuantity.Text = album.quantity.ToString();
                lblRate.Text = album.rate.ToString();
                lblUnitPrice.Text = album.unitPrice.ToString();
                txtId.Text = album.albumId.ToString();
                lblDesc.Text = album.description;
                //}
                //else 
                //{
                //    Response.Redirect("ProductBySearch.aspx");
                //}
            }          
        }
        catch (Exception ex)
        {
            lblAlbumId.Text = ex.Message;
        }
    }
    public void BindComment() 
    {

        try
        {
            CommentDao comDao = new CommentDao();
            string id = lblAlbumId.Text;

            List<Comments> list = comDao.FindAll2(Convert.ToInt32(id));
            RepeaterComment.DataSource = list;
            RepeaterComment.DataBind();
        }
        catch (Exception ex)
        {
            txtComment.Text = ex.Message;              
        }
    }

    protected void lbtnAddtoCart_Click(object sender, EventArgs e)
    {
        Object cart = Session["ShoppingCart"];
        ShoppingCart scart = null;
        if (cart == null)
        {
            scart = new ShoppingCart();
        }
        else
        {
            scart = cart as ShoppingCart;
        }
        int quantity = Convert.ToInt32(txtQuantity.Text);
        int id = Convert.ToInt32(txtId.Text);
        scart.AddtoCart(id, quantity);
        Session["ShoppingCart"] = scart;
        //LblMessage.Text = scart.List.Count.ToString();
    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        Comment();
    }

    public void Comment() 
    {
        if (Session["user"] != null)
        {
            try
            {
                CommentDao dao = new CommentDao();
                Comments com = new Comments
                {
                    customerEmail = new Customers
                    {
                        email = Session["user"].ToString(),
                    },
                    albumId = new Albums
                    {
                        albumId = Convert.ToInt32(lblAlbumId.Text),
                    },
                    comment = txtComment.Text,
                    status = 1,
                    date = DateTime.Now,
                };
                if (dao.Insert(com))
                {
                    Response.Redirect("ProductDetails.aspx?id=" + Convert.ToInt32(lblAlbumId.Text));
                }
                else
                {
                    txtComment.Text = "Comment eo dc";
                }
            }
            catch (Exception ex)
            {
                txtComment.Text = ex.Message;
            }
        }
    }

    public void BindAlbumPre() 
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            List<Albums> list = dao.FindAlbumsByStatus(3);
            RepeaterPre.DataSource = list;
            RepeaterPre.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }
    public void BindAlbumActive()
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            List<Albums> list = dao.FindAlbumsByStatus(1);
            RepeaterActive.DataSource = list;
            RepeaterActive.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
   
}