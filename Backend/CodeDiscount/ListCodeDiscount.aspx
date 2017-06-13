<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListCodeDiscount.aspx.cs" Inherits="Backend_CodeDiscount_ListCodeDiscount" %>

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
            <a href="#">List Code Sales</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Code Sales</h2>
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
                                        <th>Code ID</th>
                                        <th>Begin Date</th>
                                        <th>End Date</th>
                                        <th>PercentSale</th>
                                        <th>Status</th>
                                        <th>Code</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>                     
                            <tr>
                                <td class="center"><%# Eval("CodeId") %></td>
                                <td class="center"><%# Eval("BeginDate") %></td>
                                <td class="center"><%# Eval("EndDate") %></td>
                                <td class="center"><%# Eval("PercentSales") %></td>
                                <td class="center">
                                    <span class="label label-success"><%# int.Parse(Eval("Status").ToString()) == 1 ?"Active":"" %></span>
                                    <span class="label label-important"><%# int.Parse(Eval("Status").ToString()) == 2?"Banned":"" %></span>                          
                                </td>
                                <td class="center"><%# Eval("Code") %></td>
                                <td class="center">
                                     <asp:LinkButton ID="LinkDelete" CommandArgument='<%# Eval("CodeId") %>' CssClass="btn btn-danger" OnClick="LinkDelete_Click" runat="server"><i class="halflings-icon white trash"></i></asp:LinkButton>                          
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
</asp:Content>

