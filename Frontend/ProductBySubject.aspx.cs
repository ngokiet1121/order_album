using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_ProductBySubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindAlbum();
        }
    }
    
    public void BindAlbum()
    {
        try
        {
            AlbumDao dao = new AlbumDao();
            string idgroup = Request.QueryString["idgroup"];
            string idgenres = Request.QueryString["idgenres"];
            string idProducer = Request.QueryString["idProducer"];
            string status = Request.QueryString["status"]; 
            if (idgroup != null)
            {
                List<Albums> listGroup = dao.FindAlbumsByGroups(Convert.ToInt32(idgroup));
                if (listGroup.Count > 0)
                {
                    Repeater.DataSource = listGroup;
                    Repeater.DataBind();
                }
                else 
                {
                    Response.Redirect("ProductBySearch.aspx");
                }
            }
            else if (idgenres != null)
            {
                List<Albums> listGenres = dao.FindAlbumsByGenres(Convert.ToInt32(idgenres));
                if (listGenres.Count > 0)
                {
                    Repeater.DataSource = listGenres;
                    Repeater.DataBind();
                }
                else
                {
                    Response.Redirect("ProductBySearch.aspx");
                }
            }
            else if (idProducer != null) 
            {
                List<Albums> listProducer = dao.FindAlbumsByProducer(Convert.ToInt32(idProducer));
                if (listProducer.Count > 0)
                {
                    Repeater.DataSource = listProducer;
                    Repeater.DataBind();
                }
                else
                {
                    Response.Redirect("ProductBySearch.aspx");
                }
            }
            else if (status != null)
            {
                List<Albums> listStatus = dao.FindAlbumsByStatus(Convert.ToInt32(status));
                if (listStatus.Count > 0)
                {
                    Repeater.DataSource = listStatus;
                    Repeater.DataBind();
                }
                else
                {
                    Response.Redirect("ProductBySearch.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

}