<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Frontend_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <section id="cart_items">
        <div class="container">
            <div class="breadcrumbs">
                <ol class="breadcrumb">
                    <li><a href="#">Home</a></li>
                    <li class="active">Check out</li>
                </ol>
            </div>
            <!--/breadcrums-->

            <div class="step-one">
                <h2 class="heading">Step1</h2>
            </div>
            <div class="checkout-options">
                <h3>New User</h3>
                <p>Checkout options</p>
                <ul class="nav">
                    <li>
                        <label>
                            <asp:RadioButton ID="rdo1" GroupName="Check" runat="server" />
                            Credit card payments</label>
                    </li>
                    <li>
                        <label>
                            <asp:RadioButton ID="rdo2" GroupName="Check" runat="server" />
                            Direct payment on delivery</label>
                    </li>
                    <li>
                        <a href=""><i class="fa fa-times"></i>Cancel</a>
                    </li>
                </ul>
            </div>
            <!--/checkout-options-->

            <div class="register-req">
                <p>Please use Register And Checkout to easily get access to your order history, or use Checkout as Guest</p>
            </div>
            <!--/register-req-->
            <div class="shopper-informations">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="login-form">
                            <p>Customer</p>
                            <div class="control-group">
                                <div class="controls">
                                    <asp:TextBox ID="txtName" CssClass="span6 typeahead" Enabled="false" placeholder="Full Name" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="controls">
                                    <asp:TextBox ID="txtEmail" CssClass="span6 typeahead" Enabled="false" TextMode="Email" placeholder="Email" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="control-group">
                                <div class="controls">
                                    <asp:TextBox ID="txtPhone" CssClass="span6 typeahead" Enabled="false" placeholder="Phone" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="controls">
                                    <asp:TextBox ID="txtAddress" CssClass="span6 typeahead" Enabled="false" placeholder="Address" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="signup-form">
                            <p>Shipment</p>
                            <asp:TextBox ID="txtShipmentName" placeholder="Name"
                                runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtShipmemtEmail" placeholder="Email Address"
                                runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtShipmentPhone" placeholder="Phone"
                                runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtShipmentAddress" placeholder="Address"
                                runat="server"></asp:TextBox>
                        </div>
                        <!--/sign up form-->
                    </div>
                    
                    <div class="col-sm-4">
                        <div class="order-message">
                            <asp:TextBox ID="txtNote" TextMode="MultiLine" Rows="16" placeholder="Notes about your order, Special Notes for Delivery" runat="server"></asp:TextBox>                      
                        </div>
                    </div>
                   <div class="col-sm-4">
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btncheckOut" CssClass="btn btn-primary" OnClick="btncheckOut_Click" runat="server" Text="Check Out" />
                    </div>
                </div>
            </div>
            <div class="review-payment">
                <h2>Review & Payment</h2>
            </div>
            <asp:Repeater ID="RepeaterCart" runat="server">
                <HeaderTemplate>
                    <div class="table-responsive cart_info">
                        <table class="table table-condensed">
                            <thead>
                                <tr class="cart_menu">
                                    <td class="image">Item</td>
                                    <td class="description"></td>
                                    <td class="price">Price</td>
                                    <td class="quantity">Quantity</td>
                                    <td class="total">Total</td>
                                    <td></td>
                                </tr>
                            </thead>
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cart_product">
                            <a href="">
                                <img src="<%# Eval("Image") %>" style="width: 100px;" alt="" /></a>
                        </td>
                        <td class="cart_description">
                            <h4><a href=""><%# Eval("Name") %></a></h4>
                            <p><%# Eval("AlbumId.AlbumId") %></p>
                        </td>
                        <td class="cart_price">
                            <p>$<%# Eval("Unitprice") %></p>
                        </td>
                        <td class="cart_quantity">
                            <div class="cart_quantity_button">
                                <asp:LinkButton ID="lbtnSub" CommandArgument='<%# Eval("AlbumId.AlbumId") %>' OnClick="lbtnSub_Click" CssClass="cart_quantity_down" runat="server">-</asp:LinkButton>
                                <span id="Span1" class="cart_quantity_input"
                                    name="quantity" value="1" autocomplete="off"
                                    size="2" runat="server"><%# Eval("Quantity") %></span>
                                <asp:LinkButton ID="lbtnAdd" CommandArgument='<%# Eval("AlbumId.AlbumId") %>' OnClick="lbtnAdd_Click" CssClass="cart_quantity_up" runat="server">+</asp:LinkButton>
                            </div>
                        </td>
                        <td class="cart_total">
                            <p class="cart_total_price">$<%# Eval("TotalPrice") %></p>
                        </td>
                        <td class="cart_delete">
                            <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("AlbumId.AlbumId") %>' OnClick="btnRemove_Click" CssClass="cart_quantity_delete" runat="server"><i class="fa fa-times"></i</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <div class="table-responsive cart_info">
                <table class="table table-condensed">
                    <tr>
                        <td colspan="4">&nbsp;</td>
                        <td colspan="2">
                            <table class="table table-condensed total-result">
                                <tr>
                                    <td>Cart Sub Total</td>
                                    <td>$<asp:Label ID="lblSubtotal" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Exo Tax</td>
                                    <td>$<asp:Label ID="lblTax" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr class="shipping-cost">
                                    <td>Shipping Cost</td>
                                    <td>$<asp:Label ID="lblShippingCost" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Total</td>
                                    <td><span>$<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>                 
           </div>        
        </div>
    </section>
    <!--/#cart_items-->
</asp:Content>

