using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_customer_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
           
            if (Session["user"] != null)
            {
                BindData();
                BindHistory();
            }
            else 
            {
                Response.Redirect("Logout.aspx");
            }
           
        }
    }
    public void BindData()
    {
        try
        {

            CustomerDao dao = new CustomerDao();
            Customers cus = dao.FindCustomer(Session["user"].ToString());
            lblCusName.Text = cus.fullName;
            lblCusEmail.Text = cus.email;
            lblAddress.Text = cus.address;
            lblCusPhone.Text = cus.phone;
            lblDOB.Text = cus.dateOfBirth.Year.ToString() + "/" + cus.dateOfBirth.Month.ToString() + "/" + cus.dateOfBirth.Day.ToString();
            if (cus.gender == false)
            {
                lblGender.Text = "Female";
            }
            else
            {
                lblGender.Text = "Male";
            }
            lblCusRegDate.Text = cus.registeredDate.ToString();
            txtFullname.Text = cus.fullName;
            txtEmail.Text = cus.email;
            txtAddress.Text = cus.address;
            txtPhone.Text = cus.phone;
            txtDOB.Text = cus.dateOfBirth.Year.ToString() + "/" + cus.dateOfBirth.Month.ToString() + "/" + cus.dateOfBirth.Day.ToString();
            ddlGender.SelectedValue = cus.gender.ToString();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void BindHistory() 
    {
        try
        {
            OrderDao dao = new OrderDao();

            List<Orders> list = dao.FindAllByCustomer(Session["user"].ToString());
            RepeaterHistory.DataSource = list;
            RepeaterHistory.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;  
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {       
            CustomerDao dao = new CustomerDao();
            Customers cus = new Customers
            {
               
                fullName = txtFullname.Text,
                phone = txtPhone.Text,
                dateOfBirth = Convert.ToDateTime(txtDOB.Text),
                address = txtAddress.Text,
                gender = Convert.ToBoolean(ddlGender.SelectedValue),
                email = txtEmail.Text,
            };
            if (dao.Update(cus))
            {
                Response.Redirect("customer-profile.aspx");
            }
            else
            {
                Response.Redirect("index.aspx");
            }       
    }
    protected void lblCancel_Click(object sender, EventArgs e)
    {
        try
        {
            OrderDao dao = new OrderDao();
            LinkButton lbtn = sender as LinkButton;
            int id = Convert.ToInt32(lbtn.CommandArgument);
            Orders order = new Orders
            {
                orderId = id,
                status = 3,               
            };
            if (dao.CancelOrder(order)) 
            {
                OrderDetailsDao orderdetailDao = new OrderDetailsDao();
                List<OrderDetails> list = orderdetailDao.FindAll(id);
                AlbumDao adao = new AlbumDao();
                List<Albums> albumList = new List<Albums>();
                foreach (var item in list)
                {
                    Albums album = new Albums
                    {
                        albumId = item.albumId.albumId,
                        quantity = item.quantity
                    };
                    albumList.Add(album);
                }
                if (adao.UpdateQuantityAdd(albumList))
                {
                    Response.Redirect("customer-profile.aspx");
                }       
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerDao dao = new CustomerDao();
            Customers cus = dao.FindCustomer(Session["user"].ToString());
            if (cus.password.Equals(Help.md5(txtOldPass.Text)) && txtNewPass.Text.Equals(txtComfirm.Text))
            {
                if (dao.ChangePass(cus.email, Help.md5(txtNewPass.Text)))
                {                   
                    Response.Redirect("Logout.aspx");
                }
            }
            else 
            {
                lblMessage.Text = "Error Change";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}