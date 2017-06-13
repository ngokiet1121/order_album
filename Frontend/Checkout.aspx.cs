using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Frontend_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                CustomerDao dao = new CustomerDao();
                Customers cus = dao.FindCustomer(Session["user"].ToString());
                txtEmail.Text = cus.email;
                txtName.Text = cus.fullName;
                txtPhone.Text = cus.phone;
                txtAddress.Text = cus.address;
            }
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
        catch (Exception ex)
        {

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
            BindData();
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
        BindData();

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
        BindData();
    }
    protected void btncheckOut_Click(object sender, EventArgs e)
    {
        if (txtShipmentName.Text.Equals("") && txtShipmemtEmail.Text.Equals("") && txtShipmentPhone.Text.Equals("") && txtShipmentAddress.Text.Equals(""))
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login-Register.aspx");
            }
            OrderDao dao = new OrderDao();
            Orders order = new Orders
            {
                status = 4,
                customerEmail = new Customers
                {
                    email = Session["user"].ToString(),
                },
                orderDate = DateTime.Now,
                totalAmount = float.Parse(lblTotal.Text),
                note = txtNote.Text,
                employeeEmail = new Employees
                {
                    email = "ngoletuankiet1@gmail.com",
                },
                receivedDate = Convert.ToDateTime(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day + 3)),
                shipmentId = new Shipments
                {
                    shipmentId = 6
                },
            };
            if (dao.Insert(ref order))
            {
                int id = order.orderId;
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
                OrderDetailsDao dDao = new OrderDetailsDao();
                AlbumDao adao = new AlbumDao();
                foreach (var item in (cart as ShoppingCart).List)
                {
                    OrderDetails details = new OrderDetails
                    {
                        orderId = new Orders
                        {
                            orderId = id
                        },
                        albumId = new Albums
                        {
                            albumId = item.albumId.albumId
                        },
                        quantity = item.quantity,
                        unitprice = item.unitprice,
                        codeId = new CodeSales
                        {
                            codeId = 1,
                        },
                        tax = float.Parse(lblTax.Text),
                        shippingFee = float.Parse(lblShippingCost.Text),
                        note = txtNote.Text,
                        image = item.image,
                    };

                    if (dDao.Insert(details))
                    {

                        lblMessage.Text = "Them Orderdetail thanh cmn cong";
                    }
                }
                List<Albums> albumList = new List<Albums>();
                foreach (var item in (cart as ShoppingCart).List)
                {
                    Albums album = new Albums
                    {
                        albumId = item.albumId.albumId,
                        quantity = item.quantity
                    };
                    albumList.Add(album);
                }
                if (adao.UpdateQuantity(albumList))
                {
                    Session["ShoppingCart"] = null;
                    Response.Redirect("customer-profile.aspx");
                }       
            }
            else
            {
                lblMessage.Text = "chua them dc";
            }
        }
        else if (txtShipmentName.Text.Equals("") || txtShipmemtEmail.Text.Equals("") || txtShipmentPhone.Text.Equals("") || txtShipmentAddress.Text.Equals(""))
        {

            lblMessage.Text = "nhap day du tat ca cac truong cua shipment hoac khong nhap gi ca";
        }
        else
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login-Register.aspx");
            }
            ShipmentDao shipmentDao = new ShipmentDao();
            Shipments shipment = new Shipments
            {
                name = txtShipmentName.Text,
                email = txtShipmemtEmail.Text,
                phone = txtShipmentPhone.Text,
                address = txtShipmentAddress.Text
            };

            shipmentDao.Insert(ref shipment);
            OrderDao dao = new OrderDao();
            Orders order = new Orders
            {
                status = 4,
                customerEmail = new Customers
                {
                    email = Session["user"].ToString(),
                },
                orderDate = DateTime.Now,
                totalAmount = float.Parse(lblTotal.Text),
                note = txtNote.Text,
                employeeEmail = new Employees
                {
                    email = "ngoletuankiet1@gmail.com",
                },
                receivedDate = Convert.ToDateTime(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day + 3)),

                shipmentId = new Shipments
                {
                    shipmentId = shipment.shipmentId
                },
            };
            if (dao.Insert(ref order))
            {
                {
                    int id = order.orderId;
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
                    OrderDetailsDao dDao = new OrderDetailsDao();
                    AlbumDao adao = new AlbumDao();
                    foreach (var item in (cart as ShoppingCart).List)
                    {
                        OrderDetails details = new OrderDetails
                        {
                            orderId = new Orders
                            {
                                orderId = id
                            },
                            albumId = new Albums
                            {
                                albumId = item.albumId.albumId
                            },
                            quantity = item.quantity,
                            unitprice = item.unitprice,
                            codeId = new CodeSales
                            {
                                codeId = 1,
                            },
                            tax = float.Parse(lblTax.Text),
                            shippingFee = float.Parse(lblShippingCost.Text),
                            note = txtNote.Text,
                            image = item.image,
                        };

                        if (dDao.Insert(details))
                        {
                            lblMessage.Text = "Success";                        
                        }
                    }
                    List<Albums> albumList = new List<Albums>();
                    foreach (var item in (cart as ShoppingCart).List)
                    {
                        Albums album = new Albums
                        {
                            albumId = item.albumId.albumId,
                            quantity = item.quantity
                        };
                        albumList.Add(album);
                    }
                    if (adao.UpdateQuantity(albumList)) 
                    {
                        Session["ShoppingCart"] = null;
                        Response.Redirect("customer-profile.aspx");
                    }                                    
                }
            }
            else
            {
                lblMessage.Text = "chua them dc";
            }
        }
    }
}