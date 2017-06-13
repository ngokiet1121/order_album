<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListMadeIn.aspx.cs" Inherits="Backend_MadeIn_ListMadeIn" %>

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
                <a href="#">List Producers</a>
            </li>
        </ul>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2><i class="halflings-icon white user"></i><span class="break"></span>Producers</h2>
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
                                        <th>MadeInID</th>
                                        <th>Name</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>                     
                            <tr>
                                <td class="center"><%# Eval("ProducerId") %></td>
                                <td class="center"><%# Eval("Name") %></td>
                                <td class="center">
                                    <a class="btn btn-info" href='EditMadeIn.aspx?id=<%# Eval("ProducerId") %>'>
                                        <i class="halflings-icon white edit"></i>
                                    </a>
                                    <a class="btn btn-danger" href='Delete.aspx?id=<%# Eval("ProducerId") %>'>
                                        <i class="halflings-icon white trash"></i>
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
    </form>
    <!--/row-->
</asp:Content>

