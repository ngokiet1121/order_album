<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Frontend.master" AutoEventWireup="true" CodeFile="ProductBySubject.aspx.cs" Inherits="Frontend_ProductBySubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="col-sm-9 padding-right">
        <div class="features_items">
            <!--features_items-->
            
            <asp:Repeater ID="Repeater" runat="server">
                <HeaderTemplate>
                    <h2 class="title text-center">Items</h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-4">
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
                                      <a href="ProductDetails.aspx?id=<%# Eval("AlbumId") %>" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Details</a> </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>                
            </asp:Repeater>                             
        </div>
        <!--features_items-->
    </div>
</asp:Content>

