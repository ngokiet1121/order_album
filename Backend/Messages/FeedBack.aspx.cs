using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Messages_FeedBack : System.Web.UI.Page
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
            string id = Request.QueryString["id"];
            Messages msg = dao.SearchId(Convert.ToInt32(id));
            txtCustomerEmail.Text = msg.customerEmail.email;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("ngoletuankiet1@gmail.com");
            mail.To.Add(txtCustomerEmail.Text);
            mail.Subject = txtSubJect.Text;
            mail.Body = textarea2.Text;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ngoletuankiet1@gmail.com", "kirito1121");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            lblMessage.Text = "mail Send";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}