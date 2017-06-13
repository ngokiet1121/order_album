using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Common_FrontEnd : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AutoDeleteOrder();
            BindGroup();
            BindGenres();
            BindProducer();
            BindRandomBanner();
            if (Session["user"] != null)
            {
                lblAcount.Text = Session["user"].ToString();
            }

        }
    }
    public void BindRandomBanner()
    {
        try
        {
            Random random = new Random();
            BannerGroupDao dao = new BannerGroupDao();
            List<BannerGroups> list = dao.FindAll();
            var banners = list;
            int index1 = random.Next(banners.Count);
            int index2 = random.Next(banners.Count);
            int index3 = random.Next(banners.Count);

            Image1.ImageUrl = "../Images/banner/" + banners[index1].image; ;

            Image2.ImageUrl = "../Images/banner/" + banners[index2].image; ;

            Image3.ImageUrl = "../Images/banner/" + banners[index3].image; ;


        }
        catch (Exception)
        {

        }
    }
    public void BindGroup()
    {
        try
        {
            GroupDao dao = new GroupDao();
            List<Groups> list = dao.FindAll();
            RepeaterGroup.DataSource = list;
            RepeaterGroup.DataBind();
        }
        catch (Exception)
        {

        }
    }
    public void BindGenres()
    {
        try
        {
            GenresDao dao = new GenresDao();
            List<Genres> list = dao.FindAll();
            RepeaterGenres.DataSource = list;
            RepeaterGenres.DataBind();
        }
        catch (Exception)
        {

        }
    }
    public void BindProducer()
    {
        try
        {
            ProducerDao dao = new ProducerDao();
            List<Producers> list = dao.FindAll();
            RepeaterProducer.DataSource = list;
            RepeaterProducer.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductDetails.aspx?name=" + txtSearch.Text);
    }

    public void AutoDeleteOrder() 
    {
        OrderDao dao = new OrderDao();
        CollectionDao colleDao = new CollectionDao();
        List<Orders> list = dao.FillAll();
        Orders order = new Orders();
        int index;
        for (index = 1; index < list.Count; index++)
        {           
            order = list[index];
            OrderDetailsDao detailDao = new OrderDetailsDao();
            if (order.status == 4 && ((order.orderDate.Day + 1) < DateTime.Now.Day && order.orderDate.Month ==DateTime.Now.Month))
            {
                if (dao.Changestatus(order.orderId,2))
                { 
                colleDao.SendEmail(order.customerEmail.email, "Your order run away", "Check in your History \n Order run is " + order.orderId );
                }
            }
        }
    }
}
