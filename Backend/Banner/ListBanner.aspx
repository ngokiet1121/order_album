<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListBanner.aspx.cs" Inherits="Backend_Banner_ListBanner" %>

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
            <a href="#">List Banner</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Banner</h2>
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
                                        <th>Banner ID</th>
                                        <th>Banner</th>
                                        <th>Group</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>                     
                            <tr>
                                <td class="center"><%# Eval("BannerId") %></td>
                                <td class="center">
                                    <img src="../../Images/banner/<%# Eval("Image") %>" />
                                </td>
                                <td class="center"><%# Eval("GroupId.Name") %></td>
                                <td class="center">
                                    <a class="btn btn-info" href='EditBanner.aspx?id=<%# Eval("BannerId") %>'>
                                        <i class="halflings-icon white edit"></i>
                                    </a>
                                     <asp:LinkButton ID="LinkDelete" CommandArgument='<%# Eval("BannerId") %>' CssClass="btn btn-danger" OnClick="LinkDelete_Click" runat="server"><i class="halflings-icon white trash"></i></asp:LinkButton>                          
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

