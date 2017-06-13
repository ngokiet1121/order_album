<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListStaff.aspx.cs" Inherits="Backend_Staff_ListStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <form runat="server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="index.html">Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">List Employees</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Employees</h2>
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
                            <th>Email</th>
                            <th>Full name</th>
                            <th>Date Of Birth</th>
                            <th>Phone</th>
                            <th>Address</th>
                            <th>Gender</th>
                            <th>Role</th>
                            <th>Status</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="center"><%# Eval("Email") %></td>
                            <td class="center"><%# Eval("FullName") %></td>
                            <td class="center"><%# Eval("DateOfBirth.Day") %>/<%# Eval("DateOfBirth.Month") %>/<%# Eval("DateOfBirth.Year") %></td>
                            <td class="center"><%# Eval("Phone") %></td>
                            <td class="center"><%# Eval("Address") %></td>
                            <td class="center"><%# bool.Parse(Eval("Gender").ToString())?"Male":"Female" %>
                            </td>
                            <td class="center">
                                <span class="label label-success"><%# int.Parse(Eval("Role").ToString()) == 1 ?"Admin":"" %></span>
                                <span class="label label-important"><%# int.Parse(Eval("Role").ToString()) == 2?"Staff":"" %></span>
                                
                            </td>               
                            <td class="center">
                               <div><span  class="label label-success"><%# int.Parse(Eval("Status").ToString()) == 1 ?"Active":"" %></span></div>
                               <span  class="label label-important"><%# int.Parse(Eval("Status").ToString()) == 2?"Banned":"" %></span>
                               <span  class="label label-warning"><%# int.Parse(Eval("Status").ToString()) == 3?"Pending":"" %></span>
                            </td>
                            <td class="center">
                                <a class="btn btn-info" href='EditStaff.aspx?id=<%#Eval("Email") %>'>
                                    <i class="halflings-icon white edit"></i>
                                </a>
                               <asp:LinkButton ID="LinkDelete" CommandArgument='<%# Eval("Email") %>' 
                                    CssClass="btn btn-danger" OnClick="LinkDelete_Click" runat="server">
                                    <i class="halflings-icon white trash"></i></asp:LinkButton>
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

