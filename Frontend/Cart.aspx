<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Frontend_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <section id="cart_items">
        <div class="container">
            <div class="breadcrumbs">
                <ol class="breadcrumb">
                    <li><a href="#">Home</a></li>
                    <li class="active">Shopping Cart</li>
                </ol>
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
                                <img src="<%# Eval("Image") %>" style=" width: 100px;" alt="" /></a>
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
                                <span class="cart_quantity_input"
                                    name="quantity" value="1" autocomplete="off"
                                    size="2" runat="server"><%# Eval("Quantity") %></span>
                                <asp:LinkButton ID="lbtnAdd" CommandArgument='<%# Eval("AlbumId.AlbumId") %>' OnClick="lbtnAdd_Click" CssClass="cart_quantity_up" runat="server">+</asp:LinkButton>
                            </div>
                        </td>
                        <td class="cart_total">
                            <p class="cart_total_price">$<%# Eval("TotalPrice") %></p>
                        </td>
                        <td class="cart_delete">
                            <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("AlbumId.AlbumId") %>' OnClick="btnRemove_Click" CssClass="cart_quantity_delete" runat="server" ><i class="fa fa-times"></i</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </section>
    <!--/#cart_items-->

    <section id="do_action">
        <div class="container">
            <div class="heading">
                <h3>What would you like to do next?</h3>
                <p>Choose if you have a discount code or reward points you want to use or would like to estimate your delivery cost.</p>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="chose_area">
                        <ul class="user_info">
                            <li class="single_field zip-field">
                                <label>Code Sale:</label>
                                <asp:TextBox ID="txtCodeSale" runat="server"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="total_area">
                        <ul>
                            <li>Cart Sub Total <span>$
                                <asp:Label ID="lblSubtotal" runat="server" Text=""></asp:Label></span></li>
                            <li>Eco Tax <span>$<asp:Label ID="lblTax" runat="server" Text=""></asp:Label></span></li>
                            <li>Shipping Cost <span>$<asp:Label ID="lblShippingCost" runat="server" Text=""></asp:Label></span></li>
                            <li>Total <span>$<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></span></li>
                        </ul>
                        <asp:LinkButton ID="lblCheckOut"  style="margin-left:40px" CssClass="btn btn-default check_out" OnClick="lblCheckOut_Click" runat="server">Check Out</asp:LinkButton>
                      <%--  <a class="btn btn-default check_out" style="margin-left:40px" href="Checkout.aspx">Check Out</a>
                       --%> 
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/#do_action-->
</asp:Content>

