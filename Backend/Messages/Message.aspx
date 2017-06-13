<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Backend_Messages_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
             <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li><a href="#">Messages</a></li>
    </ul>

    <div class="row-fluid">

        <div class="span7" style="width: 100%;">
            <h1>Inbox</h1>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <ul class="messagesList">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="FeedBack.aspx?id=<%# Eval("MessageId") %>">
                           <span class="from"><span class="glyphicons star"><i></i></span><%# Eval("CustomerEmail.FullName") %></span></span><span class="title"><%# Eval("Message") %></span><span class="date"><%# Eval("DateSend.Day") %>/<%# Eval("DateSend.Month") %>/<%# Eval("DateSend.Year") %></span>						
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

