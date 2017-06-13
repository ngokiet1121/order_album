using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            MessageDao dao = new MessageDao();
            Messages msg = new Messages
            {
                customerEmail = new Customers 
                {
                    email = txtEmail.Text,               
                },
                subject = txtSubjeck.Text,
                message = txtMessage.Text,
                status = 2,      
                dateSend = DateTime.Now,
            };
            if (dao.Insert(msg))
            {
                lblMessage.Text = "Mail Sent";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }
    }
}