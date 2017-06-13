<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ListOrders.aspx.cs" Inherits="Backend_Orders_ListOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    
    <ul class="breadcrumb">
        <li>
           <i class="icon-home"></i>
					<a href="../index.aspx">Home</a>
					<i class="icon-angle-right"></i> 
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">List Order</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Orders</h2>
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
                                    <th>Order Id</th>
                                    <th>Customer</th>
                                    <th>OrderDate</th>
                                    <th>Total Amount</th>
                                    <th>Staff</th>
                                    <th>Received Date</th>
                                    <th>Shipment Id</th>
                                    <th>Note</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center"><%# Eval("OrderId") %></td>
                        <td class="center"><%# Eval("CustomerEmail.FullName") %></td>
                        <td class="center"><%# Eval("OrderDate.Day") %>/<%# Eval("OrderDate.Month") %>/<%# Eval("OrderDate.Year") %></td>
                        <td class="center"><%# Eval("TotalAmount") %></td>
                        <td class="center"><%# Eval("EmployeeEmail.FullName") %></td>
                        <td class="center"><%# Eval("ReceivedDate.Day") %>/<%# Eval("ReceivedDate.Month") %>/<%# Eval("ReceivedDate.Year") %></td>
                        <td class="center"><%# Eval("ShipmentId.Email") %></td>
                        <td class="center"><%# Eval("Note") %>
                        </td>
                        <td class="center">
                            <a class="label label-success" data-toggle="modal" href="#<%# Eval("OrderId") %>"><%# int.Parse(Eval("Status").ToString()) == 1 ?"In Progress":"" %></a>
                            <a class="label label-important" data-toggle="modal" href="#<%# Eval("OrderId") %>"><%# int.Parse(Eval("Status").ToString()) == 2?"Solved":"" %></a>
                            <a class="label label-warning" data-toggle="modal" href="#<%# Eval("OrderId") %>"><%# int.Parse(Eval("Status").ToString()) == 3?"Cancel":"" %></a>
                              <a class="label label-error"><%# int.Parse(Eval("Status").ToString()) == 4?"Waiting":"" %></a>
                        </td>
                        <td class="center">
                            <a class="btn btn-success" title="Details" href='OrderDetails.aspx?orderId=<%# Eval("OrderId") %>'>
                                <i class="halflings-icon white search"></i>
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
    <form runat="server">
        <asp:Repeater ID="RepeaterStatus" runat="server">
            <ItemTemplate>
                <div class="modal fade" id='<%# Eval("OrderId") %>' role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 id="yes" class="modal-title" >Change status</h4>
                            </div>                          
                            <div id="change" class="modal-footer">
                                <%--<asp:Button ID="Button1" CssClass="btn btn-primary" i runat="server" Text="Button" />--%>
                                <asp:LinkButton ID="lbtnInProgress" CommandArgument='<%# Eval("OrderId") %>' CssClass="btn btn-success" OnClick="lbtnInProgress_Click"  runat="server">In Progress</asp:LinkButton>
                                <asp:LinkButton ID="lbtnSolved" CommandArgument='<%# Eval("OrderId") %>' CssClass="btn btn-danger" OnClick="lbtnSolved_Click" runat="server">Solved</asp:LinkButton>
                                <asp:LinkButton ID="lbtnCancel" CommandArgument='<%# Eval("OrderId") %>' CssClass="btn btn-warning" OnClick="lbtnCancel_Click"  runat="server">Cancel</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
    <!--/row-->
</asp:Content>

