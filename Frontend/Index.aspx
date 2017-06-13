<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Frontend.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Frontend_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <asp:Repeater ID="RepeaterItem" runat="server">
        <HeaderTemplate>
            <div class="col-sm-9 padding-right">
                <div class="features_items">
                    <!--features_items-->
                    <h2 class="title text-center">Features Items</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-sm-4" style="height:358px">
                <div class="product-image-wrapper">
                    <div class="single-products">
                        <div class="productinfo text-center">
                            <img src="<%# Eval("Image") %>" alt="" />
                            <h2>$<%# Eval("UnitPrice") %></h2>
                            <p><%# Eval("Name") %></p>
                         </div>
                        <div class="product-overlay">
                            <div class="overlay-content">
                                <h2>$<%# Eval("UnitPrice") %></h2>                    
                                 <p><%# Eval("Name") %></p>
                                 <a href="ProductDetails.aspx?id=<%# Eval("AlbumId") %>" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Details</a>
                       
                                <%--<asp:LinkButton ID="lbtnAddtoCart" CommandArgument='<%# Eval("AlbumId") %>' OnClick="lbtnAddtoCart_Click" CssClass="btn btn-default add-to-cart" runat="server"><i class="fa fa-shopping-cart"></i>Add to cart</asp:LinkButton>--%>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
    </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
</asp:Content>

