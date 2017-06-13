using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Shipments_EditShipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ShipmentDao dao = new ShipmentDao();
                string id = Request.QueryString["id"];
                Shipments item = new Shipments
                {
                    name = dao.FindId(Convert.ToInt32(id)).name,
                    email = dao.FindId(Convert.ToInt32(id)).email,
                    address = dao.FindId(Convert.ToInt32(id)).address,
                    phone = dao.FindId(Convert.ToInt32(id)).phone
                };

                txtName.Text = item.name.ToString();
                txtAddress.Text = item.address.ToString();
                txtEmail.Text = item.email.ToString();
                txtPhone.Text = item.phone.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ShipmentDao dao = new ShipmentDao();
            string id = Request.QueryString["id"];
            Shipments item = new Shipments
            {
                shipmentId = Convert.ToInt32(id),
                email   = txtEmail.Text,
                name = txtName.Text,
                phone = txtPhone.Text,
                address = txtAddress.Text
            };
            if (dao.Update(item))
            {
                Response.Redirect("ListShipment.aspx");
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