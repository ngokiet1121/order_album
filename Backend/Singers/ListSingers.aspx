<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListSingers.aspx.cs" Inherits="Backend_Singers_ListSingers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
             <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">List Singers</a>
        </li>
    </ul>
    <form id="Form1" runat="server">
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Singers</h2>
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
                            <th>Singer Id</th>
                            <th>Name</th>
                            <th>Gender</th>
                            <th>Date Of Birth</th>
                            <th>Group</th>
                            <th>Nationality</th>
                            <th>Description</th>
                            <th>Image</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="center"><%# Eval("SingerId") %></td>
                            <td class="center"><%# Eval("Name") %></td>
                            <td class="center"><%# bool.Parse(Eval("Gender").ToString())?"Male":"Female" %>
                            </td>
                            <td class="center"><%# Eval("DateOfBirth.Day") %>/<%# Eval("DateOfBirth.Month") %>/<%# Eval("DateOfBirth.Year") %></td>
                            <td class="center"><%# Eval("GroupId.Name") %></td>
                            <td class="center"><%# Eval("NationalityId.Name") %></td>
                            <td class="center"><%# Eval("Description") %></td>
                            <td class="center"><img src="../../Images/Singer/<%# Eval("Image") %>" /></td>
                            <td class="center">
                                <a class="btn btn-info" href='EditSinger.aspx?id=<%#Eval("SingerId") %>'>
                                    <i class="halflings-icon white edit"></i>
                                </a>
                                <asp:LinkButton ID="LinkDelete" CommandArgument='<%# Eval("SingerId") %>' 
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
    </form>
    <!--/row-->
</asp:Content>

