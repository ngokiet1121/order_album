<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="DetailHistory.aspx.cs" Inherits="Frontend_Cart" %>

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
                                    <td class="image">Image</td>
                                    <td class="price">Name</td>
                                    <td class="price">Price</td>
                                    <td class="price">Quantity</td>
                                    <td class="price">Tax</td>
                                    <td class="price">ShippingFee</td>
                                    <td class="total">Note</td>
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
                                <img src="<%# Eval("Image") %>" style=" width: 100px;" alt="" />
                            </a>
                        </td>

                        <td class="cart_price">
                            <h4><a href='ProductDetails.aspx?name=<%# Eval("AlbumId.Name") %>'><%# Eval("AlbumId.Name") %></a></h4>
                            <p><h3><%# Eval("AlbumId.AlbumId") %></h3></p>
                        </td>
                    
                        <td class="cart_price">
                            <p>$<%# Eval("Unitprice") %></p>
                        </td>
                        <td class="cart_price">
                           <p>----<%# Eval("Quantity") %>----</p>
                        </td>
                         <td class="cart_price">
                            <p>$<%# Eval("Tax") %></p>
                        </td>
                         <td class="cart_price">
                            <p>$<%# Eval("ShippingFee") %></p>
                        </td>
                          <td class="cart_total">
                            <p><%# Eval("Note") %></p>
                        </td>
                        <td class="cart_total">
                            <p class="cart_total_price">$<%# Eval("TotalPrice") %></p>
                        </td>                      
                        <td class="cart_delete">
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
    <!--/#do_action-->
</asp:Content>

