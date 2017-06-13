<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListGroup.aspx.cs" Inherits="Backend_Groups_ListGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <form id="Form1" runat="server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">List Group</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Group</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <asp:Repeater ID="Repeater" runat="server">
                <HeaderTemplate>
                    <div class="box-content">
                        <table class="table table-striped table-bordered bootstrap-datatable datatable">
                            <thead>
                                <tr>
                                    <th>GroupId</th>
                                    <th>Name</th>
                                    <th>Image</th>
                                    <th>Description</th>
                                    <th>Type</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center"><%# Eval("GroupId") %></td>  
                        <td class="center"><%# Eval("Name") %></td>
                        <td class="center">
                            <img src="../../Images/Group/<%# Eval("Image") %>" /></td>
                        <td class="center">
                            <%# Eval("Description") %>
                        </td>
                        <td class="center">
                            <span class="label label-success">
                                <%# int.Parse(Eval("Type").ToString()) == 1?"Normal":""%>
                            </span>
                            <span class="label label-important">
                                <%# int.Parse(Eval("Type").ToString()) == 2?"Special":""%>
                            </span>
                        </td>
                        <td class="center">
                            <a class="btn btn-info" href='EditGroup.aspx?id=<%# Eval("GroupId") %>'>
                                <i class="halflings-icon white edit"></i>
                            </a>
                            <asp:LinkButton ID="LinkDelete" CssClass="btn btn-danger" 
                                OnClick="LinkDelete_Click" CommandArgument='<%# Eval("GroupId") %>' runat="server">
                                <i class="halflings-icon white trash"></i>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
            </div>
                </FooterTemplate>
            </asp:Repeater>
             <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
        </div>
        <!--/span-->

    </div>
    </form>
    <!--/row-->
</asp:Content>

