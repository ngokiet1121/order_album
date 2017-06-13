using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Nationalities_ListNationality : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                NationalityDao dao = new NationalityDao();
                List<Nationalities> list = dao.FindAll();
                Repeater.DataSource = list;
                Repeater.DataBind();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
    }
}