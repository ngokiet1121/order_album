<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListShipment.aspx.cs" Inherits="Backend_Shipments_ListShipment" %>

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
            <a href="#">List Shipment</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Shipments</h2>
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
                            <th>Id</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Address</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate> 
                        <tr>
                            <td class="center"><%# Eval("ShipmentId") %></td>
                            <td class="center"><%# Eval("Name") %></td>
                            <td class="center"><%# Eval("Email") %></td>
                            <td class="center"><%# Eval("Phone") %>
                            </td>
                            <td class="center"><%# Eval("Address") %></td>
                            <td class="center">
                                <a class="btn btn-info" href='EditShipment.aspx?id=<%# Eval("ShipmentId") %>'>
                                    <i class="halflings-icon white edit"></i>
                                </a>                              
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </tbody>
                </table>
                <div class="alert-danger">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="alert-success">
                    <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                </div>
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

