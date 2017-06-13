using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Cart : System.Web.UI.Page
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
            object carts = Session["ShoppingCart"];
            if (carts != null)
            {
                lblSubtotal.Text = (carts as ShoppingCart).SubTotal.ToString();
                lblShippingCost.Text = "5";
                lblTax.Text = "5";
                lblTotal.Text = ((carts as ShoppingCart).SubTotal + 5 + 5).ToString();
                RepeaterCart.DataSource = (carts as ShoppingCart).List;
                RepeaterCart.DataBind();           
            }
        }
        catch (Exception ex){
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        Object cart = Session["ShoppingCart"];
        ShoppingCart scart = null;
        if (cart != null)
        {

            scart = cart as ShoppingCart;
            int productId = int.Parse((sender as LinkButton).CommandArgument);
            scart.Remove(productId);
            Session["ShoppingCart"] = scart;
            RepeaterCart.DataSource = scart.List;
            RepeaterCart.DataBind();
            lblSubtotal.Text = (scart as ShoppingCart).SubTotal.ToString();
            lblShippingCost.Text = "5";
            lblTax.Text = "5";
            lblTotal.Text = ((scart as ShoppingCart).SubTotal + 5 + 5).ToString();
        }      
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        Object cart = Session["ShoppingCart"];
        ShoppingCart scart = null;
        if (cart == null)
        {
            scart = new ShoppingCart();
        }
        else
        {
            scart = cart as ShoppingCart;
        }
        int id = int.Parse((sender as LinkButton).CommandArgument.ToString());
        scart.AddOne(id);
        Session["ShoppingCart"] = scart;
        RepeaterCart.DataSource = scart.List;
        RepeaterCart.DataBind();
        lblSubtotal.Text = (scart as ShoppingCart).SubTotal.ToString();
        lblShippingCost.Text = "5";
        lblTax.Text = "5";
        lblTotal.Text = ((scart as ShoppingCart).SubTotal + 5 + 5).ToString();
    }
    protected void lbtnSub_Click(object sender, EventArgs e)
    {
        Object cart = Session["ShoppingCart"];
        ShoppingCart scart = null;
        if (cart == null)
        {
            scart = new ShoppingCart();
        }
        else
        {
            scart = cart as ShoppingCart;
        }
        int id = int.Parse((sender as LinkButton).CommandArgument.ToString());
        scart.SubTract(id);
        Session["ShoppingCart"] = scart;
        RepeaterCart.DataSource = scart.List;
        RepeaterCart.DataBind();
        lblSubtotal.Text = (scart as ShoppingCart).SubTotal.ToString();
        lblShippingCost.Text = "5";
        lblTax.Text = "5";
        lblTotal.Text = ((scart as ShoppingCart).SubTotal + 5 + 5).ToString();
    }
    protected void lblCheckOut_Click(object sender, EventArgs e)
    {
         object carts = Session["ShoppingCart"];
         if (carts != null)
         {
             //CodeSaleDao dao = new CodeSaleDao();
             //CodeSales codesale = dao.SearchId(txtCodeSale.Text);
             //if (codesale.endDate.Day < DateTime.Now.Day)
             //{
             //    Session["codesale"] = null;
             //    Response.Redirect("CheckOut.aspx");
             //}
             //else
             //{
                 //Session["codesale"] = txtCodeSale.Text;
                 Response.Redirect("CheckOut.aspx");
             //}
         }
    }
    
}