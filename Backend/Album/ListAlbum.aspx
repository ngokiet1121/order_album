<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListAlbum.aspx.cs" Inherits="Backend_Album_ListAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <form runat="server">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home"></i>
                <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
                <i class="icon-angle-right"></i>
            </li>
            <li>
                <i class="icon-edit"></i>
                <a href="#">List Albums</a>
            </li>
        </ul>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2><i class="halflings-icon white user"></i><span class="break"></span>Albums</h2>
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
                                        <th>Album ID</th>
                                        <th>Name</th>
                                        <th>Quantity</th>
                                        <th>Producer</th>
                                        <th>Unitprice</th>
                                        <th>Status</th>
                                        <th>Description</th>
                                        <th>Image</th>
                                        <th>PublishedDate</th>
                                        <th>EnteredDate</th>
                                        <th>Rate</th>
                                        <th>Tags</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="center"><%# Eval("AlbumId") %></td>
                            <td class="center"><%# Eval("Name") %></td>
                            <td class="center"><%# Eval("Quantity") %></td>
                            <td class="center"><%# Eval("ProducerId.Name") %></td>
                            <td class="center"><%# Eval("UnitPrice") %></td>
                            <td class="center">
                                <a  href="#<%# Eval("AlbumId") %>" data-toggle="modal" class="label label-success"><%# int.Parse(Eval("Status").ToString()) == 1 ?"Active":"" %></a>
                                <a  href="#<%# Eval("AlbumId") %>" data-toggle="modal" class="label label-important"><%# int.Parse(Eval("Status").ToString()) == 2?"Banned":"" %></a>
                                <a  href="#<%# Eval("AlbumId") %>" data-toggle="modal" class="label label-warning"><%# int.Parse(Eval("Status").ToString()) == 3?"PreAlbum":"" %></a>
                            </td>
                            <td class="center"><%# Eval("Description") %></td>
                            <td class="center">
                                <img style="width: 100px; height: 100px" src="<%# Eval("Image") %>" />
                            </td>
                            <td class="center"><%# Eval("PublishedDate.Day") %>/<%# Eval("PublishedDate.Month") %>/<%# Eval("PublishedDate.Year") %></td>
                            <td class="center"><%# Eval("EnteredDate.Day") %>/<%# Eval("EnteredDate.Month") %>/<%# Eval("EnteredDate.Year") %></td>
                            <td class="center"><%# Eval("Rate") %></td>
                            <td class="center"><%# Eval("Tags") %></td>
                            <td class="center">
                                <a class="btn btn-info" href='EditAlbum.aspx?id=<%# Eval("AlbumId") %>'>
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
        <asp:Repeater ID="RepeaterStatus" runat="server">
            <ItemTemplate>
                <div class="modal fade" id='<%# Eval("AlbumId") %>' role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Change status</h4>
                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button ID="Button1" CssClass="btn btn-primary" i runat="server" Text="Button" />--%>
                            <asp:LinkButton ID="lbtnActive" OnClick="lbtnActive_Click" CommandArgument='<%# Eval("AlbumId") %>' CssClass="btn btn-success" runat="server">Active</asp:LinkButton>
                            <asp:LinkButton ID="lbtnBanned" OnClick="lbtnBanned_Click" CommandArgument='<%# Eval("AlbumId") %>' CssClass="btn btn-danger" runat="server">Banned</asp:LinkButton>
                            <asp:LinkButton ID="lbtnPreAlbum" OnClick="lbtnPreAlbum_Click" CommandArgument='<%# Eval("AlbumId") %>' CssClass="btn btn-warning" runat="server">PreAlbum</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
    <!--/row-->
</asp:Content>

