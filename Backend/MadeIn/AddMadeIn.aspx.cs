using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_MadeIn_AddMadeIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
           ProducerDao dao = new ProducerDao();
           Producers madein = new Producers
           {
            name = txtName.Text
           };
           if (dao.Insert(madein))
           {
               //lblMessageSuccess.Text = "New Made In Has been inserted";
               Response.Redirect("ListMadeIn.aspx");
           }
           else 
           {
               lblMessage.Text = "No MadeIn has been inserted";
           }
            
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }       
    }
}