<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Frontend.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Frontend_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="col-sm-9 padding-right">
        <div class="product-details">
            <!--product-details-->
            <div class="col-sm-5">
                <div class="view-product">
                    <%--<img src="images/product-details/1.jpg" alt="" />--%>
                    <asp:Image ID="imgAlbum"  runat="server" />
                </div>
            </div>
            <div class="col-sm-7">
                <div class="product-information">
                    <!--/product-information-->
                    <h2>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h2>
                    <p>Album ID:
                        <asp:Label ID="lblAlbumId" runat="server" Text=""></asp:Label></p>
                    <p>Producer:
                        <asp:Label ID="lblProducer" runat="server" Text=""></asp:Label></p>
                    <%--<p>Unit Price: 1089772</p> --%>
                    <p>Available:
                        <asp:Label ID="lblAvaiable" runat="server" Text=""></asp:Label></p>
                    <p>Rate:
                        <asp:Label ID="lblRate" runat="server" Text=""></asp:Label></p>
                    <p>Published Date:
                        <asp:Label ID="lblPublisherDate" runat="server" Text=""></asp:Label></p>
                    <p>Quantity:<asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label></p>
                    <span>
                        <span>$<asp:Label ID="lblUnitPrice" runat="server" Text=""></asp:Label></span>
                        <asp:TextBox ID="txtId" hidden value="3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtQuantity" value="3" runat="server"></asp:TextBox>

                        <asp:LinkButton ID="lbtnAddtoCart" OnClick="lbtnAddtoCart_Click" CssClass="btn btn-fefault cart" runat="server"><i class="fa fa-shopping-cart"></i>Add to cart</asp:LinkButton>

                    </span>
                </div>
                <!--/product-information-->
            </div>
        </div>
        <!--/product-details-->

        <div class="category-tab shop-details-tab">
            <!--category-tab-->
            <div class="col-sm-12">
                <ul class="nav nav-tabs">
                    <li><a href="#details" data-toggle="tab">Details</a></li>
                    
                    
                    <li class="active"><a href="#reviews" data-toggle="tab">Reviews (5)</a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane fade" id="details">
                    <div class="col-sm-12">
                        <div style="overflow: scroll; height: 200px">
                            <p>
                                <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                

                <div class="tab-pane fade active in" id="reviews">
                    <div class="col-sm-12">
                        <asp:Repeater ID="RepeaterComment" runat="server">
                            <HeaderTemplate>
                                <div style="overflow: scroll; height: 100px">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <ul>
                                    <li><a href=""><i class="fa fa-user"></i><%# Eval("CustomerEmail.Email") %></a></li>
                                    <li><a href=""><i class="fa fa-calendar-o"></i><%# Eval("Date.Day") %>/<%# Eval("Date.Month") %>/<%# Eval("Date.Year") %></a></li>
                                </ul>
                                <p><%# Eval("Comment") %></p>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                        <p><b>Write Your Review</b></p> 
                        <asp:TextBox ID="txtComment" TextMode="MultiLine" placeholder="Write your comment" runat="server"></asp:TextBox>
                        <asp:Button ID="btnComment" OnClick="btnComment_Click" CssClass="btn btn-default pull-right"
                            runat="server" Text="Comment" />
                        <%--<button type="button" class="btn btn-default pull-right">
                            Submit
                        </button>--%>
                    </div>
                </div>
        </div>
    </div>
    <!--/category-tab-->

    <div class="recommended_items">
        <!--recommended_items-->
        <h2 class="title text-center">recommended items</h2>

        <div id="recommended-item-carousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="item active">
                    <asp:Repeater ID="RepeaterPre" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="product-image-wrapper">
                                <div class="single-products">
                                    <div class="productinfo text-center">
                                        <img style="height:150px" src="<%# Eval("Image") %>" />
                                        <h2>$<%# Eval("Unitprice") %></h2>
                                        <p><%# Eval("Name") %></p>
                                        <a href="ProductDetails.aspx?id=<%# Eval("AlbumId") %>"  class="btn btn-default add-to-cart"
                                            > Detail</a>
                                        <%--<i class="fa fa-shopping-cart"></i>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater> 
                          
                </div>
                <div class="item">                   
                    <asp:Repeater ID="RepeaterActive" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="product-image-wrapper">
                                <div class="single-products">
                                    <div class="productinfo text-center">
                                        <img style="height:150px" src="<%# Eval("Image") %>" />
                                        <h2>$<%# Eval("Unitprice") %></h2>
                                        <p><%# Eval("Name") %></p>
                                        <a href="ProductDetails.aspx?id=<%# Eval("AlbumId") %>"  class="btn btn-default add-to-cart"
                                            > Detail</a>
                                        <%--<i class="fa fa-shopping-cart"></i>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <a class="left recommended-item-control" href="#recommended-item-carousel" data-slide="prev">
                <i class="fa fa-angle-left"></i>
            </a>
            <a class="right recommended-item-control" href="#recommended-item-carousel" data-slide="next">
                <i class="fa fa-angle-right"></i>
            </a>
        </div>
    </div>
    <!--/recommended_items-->

    </div>
</asp:Content>

