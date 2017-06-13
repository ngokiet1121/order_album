using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_MadeIn_EditMadeIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try {
                ProducerDao dao = new ProducerDao();
                string id = Request.QueryString["id"];
                Producers item = new Producers
                {                  
                    name = dao.SearchId(Convert.ToInt32(id)).name
                };

                txtName.Text = item.name.ToString();                          
            }
            catch(Exception)
            {
                
            }
        }
    }
    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ProducerDao dao = new ProducerDao();
            string id = Request.QueryString["id"];
            Producers item = new Producers
            {
                producerId = Convert.ToInt32(id),
                name = txtName.Text
            };
            if (dao.Update(item))
            {
                Response.Redirect("ListMadeIn.aspx");
            }
            else 
            {
                lblMessage.Text = "Edit Error";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}