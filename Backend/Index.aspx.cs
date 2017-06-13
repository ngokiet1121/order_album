using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Index : System.Web.UI.Page
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
            MessageDao dao = new MessageDao();
            CustomerDao cusDao = new CustomerDao();
            CommentDao cmtDao = new CommentDao();
            OrderDao orderDao = new OrderDao();
            MessageDao msgDao = new MessageDao();
            AlbumDao albumDao = new AlbumDao();
            GroupDao grDao = new GroupDao();
            List<Messages> list = dao.FindAllStatus2();   
            List<Customers> listUser = cusDao.FindAll();
            List<Comments> listComment = cmtDao.FindAll();
            List<Orders> listOrder = orderDao.FillAll();
            List<Messages> listMsg = msgDao.FindAll();
            List<Albums> listAlbum = albumDao.FindAll();
            List<Groups> listGroup = grDao.FindAll();
            lblUser.Text = listUser.Count.ToString();
            lblComment.Text = listComment.Count.ToString();
            lblOrders.Text=listOrder.Count.ToString();
            lblMessages.Text = listMsg.Count.ToString();
            lblAlbums.Text = listAlbum.Count.ToString();
            lblGroups.Text = listGroup.Count.ToString();
            Repeater.DataSource = list;
            Repeater.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void btnSeem_Click(object sender, EventArgs e)
    {
        try
        {
             MessageDao dao = new MessageDao();
             LinkButton btn = sender as LinkButton;
             int id = Convert.ToInt32(btn.CommandArgument);
             Messages msg = new Messages
             { 
                messageId = id,
                status = 1             
             };
             if (dao.Update(msg))
             {
                 Response.Redirect("http://localhost:1962/Backend/Index.aspx");
             }        
        }
        catch (Exception)
        {
            
        }
    }
}