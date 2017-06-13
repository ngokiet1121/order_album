using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Songs_EditSong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindDataAlbum();
            BindDataGenres();
            BindDataGroup();
            try
            {
                SongDao dao = new SongDao();
                string id = Request.QueryString["id"];
                Songs song = dao.FindId(Convert.ToInt32(id));
                txtSong.Text = song.name;
                txtAuthor.Text = song.authors;
                ddlAlbum.SelectedValue = song.albumId.albumId.ToString();
                ddlGenres.SelectedValue = song.genreId.genresId.ToString();
                ddlGroup.SelectedValue = song.groupId.groupId.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
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
    public void BindDataGenres()
    {
        try
        {
            GenresDao dao = new GenresDao();
            List<Genres> list = dao.FindAll();
            ddlGenres.DataSource = list;
            ddlGenres.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void BindDataGroup()
    {
        try
        {
            GroupDao dao = new GroupDao();
            List<Groups> list = dao.FindAll();
            ddlGroup.DataSource = list;
            ddlGroup.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            SongDao dao = new SongDao();
            string id = Request.QueryString["id"];
            Songs song = new Songs
            {
                songId = Convert.ToInt32(id),
                authors = txtAuthor.Text,
                name = txtSong.Text,
                groupId = new Groups 
                {
                    groupId = Convert.ToInt32(ddlGroup.SelectedValue)
                },
                albumId = new Albums
                {
                    albumId = Convert.ToInt32(ddlAlbum.SelectedValue)
                },
                genreId = new Genres
                {
                    genresId = Convert.ToInt32(ddlGenres.SelectedValue)
                },
            };
            if (dao.Update(song))
            {
                //lblMessageSuccess.Text = "Edit Success";
                Response.Redirect("ListSong.aspx");
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