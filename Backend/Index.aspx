<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Backend_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="#">Home</a>
        </li>
    </ul>
    <div class="row-fluid">
        <a class="quick-button metro yellow span2" href="Customer/ViewList.aspx">
            <i class="icon-group"></i>
            <p>Users</p>
            <span class="badge">
               <h1> <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <a class="quick-button metro red span2" href="Comments/ListComment.aspx">
            <i class="icon-comments-alt"></i>
            <p>Comments</p>
            <span class="badge">
               <h1> <asp:Label ID="lblComment" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <a class="quick-button metro blue span2" href="Orders/ListOrders.aspx">
            <i class="icon-shopping-cart"></i>
            <p>Orders</p>
            <span class="badge">
              <h1>  <asp:Label ID="lblOrders" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <a class="quick-button metro green span2" href="Album/ListAlbum.aspx">
            <i class="icon-barcode"></i>
            <p>Albums</p>
            <span class="badge">
              <h1>  <asp:Label ID="lblAlbums" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <a class="quick-button metro pink span2" href="Messages/Message.aspx">
            <i class="icon-envelope"></i>
            <p>Messages</p>
            <span class="badge">
               <h1> <asp:Label ID="lblMessages" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <a class="quick-button metro black span2" href="Groups/ListGroup.aspx">
            <i class="icon-calendar"></i>
            <p>Groups</p>
            <span class="badge">
               <h1> <asp:Label ID="lblGroups" runat="server" Text="Label"></asp:Label></h1></span>
        </a>
        <div class="clearfix"></div>
    </div>
    <!--/row-->
    <form id="Form1" runat="server">
        <asp:Repeater ID="Repeater" runat="server">
            <ItemTemplate>
                <!-- Modal content-->
                <div class="modal fade" id='<%# Eval("MessageId") %>' role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title"><%# Eval("CustomerEmail.FullName") %></h4>
                                <%# Eval("DateSend.Day") %>/<%# Eval("DateSend.Month") %>/<%# Eval("DateSend.Year") %>
                            </div>
                            <div class="modal-body">
                                <p><%# Eval("Message") %></p>
                            </div>

                            <div class="modal-footer">
                                <%--<asp:Button ID="Button1" CssClass="btn btn-primary" i runat="server" Text="Button" />--%>
                                <asp:LinkButton ID="btnSeem" CommandArgument='<%# Eval("MessageId") %>' CssClass="btn btn-primary" OnClick="btnSeem_Click" runat="server">Seem</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</asp:Content>

