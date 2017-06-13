<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ViewList.aspx.cs" Inherits="Backend_Customer_ViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <form runat="server">
    <ul class="breadcrumb">
        <li>
           <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li><a href="#">View List Customer</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Customers</h2>
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
                                   
                                    <th>UserName</th>
                                    <th>Email</th>
                                    <th>Phone</th>
                                    <th>Gender</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        
                        <td class="center"><%# Eval("FullName") %></td>
                        <td class="center"><%# Eval("Email") %></td>
                        <td class="center"><%# Eval("Phone") %></td>
                        <td class="center"><%# bool.Parse(Eval("Gender").ToString())?"Male":"Female" %></td>
                        <td class="center">
                            <span class="label label-success"><%# int.Parse(Eval("Status").ToString()) == 1 ?"Active":"" %></span>
                            <span class="label label-important"><%# int.Parse(Eval("Status").ToString()) == 2?"Banned":"" %></span>
                            <span class="label label-warning"><%# int.Parse(Eval("Status").ToString()) == 3?"Pending":"" %></span>
                        </td>
                        <td class="center">
                            <a class="btn btn-info" href="EditCustomer.aspx?id=<%# Eval("Email") %>">
                                <i class="halflings-icon white edit"></i>
                            </a>                         
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
    <!--/row-->
    </form>
</asp:Content>

