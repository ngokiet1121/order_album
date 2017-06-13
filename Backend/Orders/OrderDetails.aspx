<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="Backend_Orders_ListOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" Runat="Server">
    <ul class="breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="~/index.aspx">Home</a>
					<i class="icon-angle-right"></i> 
				</li>
                <li>
					<i class="icon-edit"></i>
					<a href="ListOrders.aspx">List Order</a>
				</li>
				<li>
					<i class="icon-edit"></i>
					<a href="#">List Order Detail</a>
				</li>
			</ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Order</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <table class="table table-striped table-bordered">
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
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="center"><asp:Label ID="lblOrderId" runat="server" Text=""></asp:Label></td>
                            <td class="center"><asp:Label ID="lblCustomer" runat="server" Text=""></asp:Label></td>
                            <td class="center"> <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label></td>
                            <td class="center"><asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
                            <td class="center"> <asp:Label ID="lblStaff" runat="server" Text=""></asp:Label></td>                         
                            <td class="center"><asp:Label ID="lblReceivedDate" runat="server" Text=""></asp:Label></td>
                            <td class="center"> <asp:Label ID="lblShipmentId" runat="server" Text=""></asp:Label></td>
                            <td class="center"><asp:Label ID="lblNote" runat="server" Text=""></asp:Label></td>                       
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--/span-->
    </div>	
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white user"></i><span class="break"></span>Order Detail</h2>
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
                            <th>Album Name</th>
                            <th>Quantity</th>
                            <th>Total Price</th>
                            <th>Code Sale</th>
                            <th>Tax</th>
                            <th>Shipping Fee</th>
                            <th>Note</th>
                            <th>Image</th>
                           
                        </tr>
                    </thead>
                    <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="center"><%# Eval("OrderId.OrderId") %></td>
                            <td class="center"><%# Eval("AlbumId.Name") %></td>
                            <td class="center"><%# Eval("Quantity") %></td>
                            <td class="center"><%# Eval("Unitprice") %></td>
                            <td class="center"><%# Eval("CodeId.Code") %></td>
                            <td class="center"><%# Eval("Tax") %></td>
                            <td class="center"><%# Eval("ShippingFee") %></td>
                            <td class="center"><%# Eval("Note") %>
                            </td>
                            <td class="center"><img src='<%# Eval("Image") %>' />
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
</asp:Content>

