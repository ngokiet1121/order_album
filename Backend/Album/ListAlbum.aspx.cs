using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Album_ListAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindData();
        }
    }


    public void BindData() 
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            Repeater.DataSource = dao.FindAll();
            Repeater.DataBind();
            RepeaterStatus.DataSource = dao.FindAll();
            RepeaterStatus.DataBind();
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.ToString();
        }
    }

    protected void LinkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            SongDao songdao = new SongDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            dao.DeleteData(id);
            
            BindData();
            lblmessage.Text = "An album has been deleted";
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }


    protected void lbtnActive_Click(object sender, EventArgs e)
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Albums album = new Albums 
            {
                albumId = id,
                status = 1,               
            };
            if (dao.UpdateStatus(album))
            {
                lblmessage.Text = "Change Success";
                Response.Redirect("ListAlbum.aspx");
            }
            else 
            {
                lblmessage.Text = "Change Error";
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void lbtnBanned_Click(object sender, EventArgs e)
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Albums album = new Albums
            {
                albumId = id,
                status = 2,
            };
            if (dao.UpdateStatus(album))
            {
                lblmessage.Text = "Change Success";
                Response.Redirect("ListAlbum.aspx");
            }
            else
            {
                lblmessage.Text = "Change Error";
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    protected void lbtnPreAlbum_Click(object sender, EventArgs e)
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Albums album = new Albums
            {
                albumId = id,
                status = 3,
            };
            if (dao.UpdateStatus(album))
            {
                lblmessage.Text = "Change Success";
                Response.Redirect("ListAlbum.aspx");
            }
            else
            {
                lblmessage.Text = "Change Error";
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
}