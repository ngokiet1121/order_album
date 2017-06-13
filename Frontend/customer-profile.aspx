<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Frontend.master" AutoEventWireup="true" CodeFile="customer-profile.aspx.cs" Inherits="Frontend_customer_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="col-sm-9">
        <div class="blog-post-area">
            <h2 class="title text-center">PROFILE CUSTOMER</h2>
            <div class="single-blog-post">
                <table id="cusprofile" style="margin: 0 auto;">
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Fullname: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCusName" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Email: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCusEmail" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Date Of Birth: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Phone: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCusPhone" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Address: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Gender: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Registered Date: </b></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCusRegDate" runat="server" Text="Label"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-bottom: 20px">
                            <a id="show" name="submit" class="btn btn-primary center">Edit</a>
                            <a id="show2" name="submit" class="btn btn-primary center">ChangePass</a>
                        </td>
                    </tr>
                </table>

                <table id="editform" style="margin: 0 auto; display: none">
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Fullname: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFullname" CssClass="inputinput" runat="server" request></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Email: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" CssClass="inputinput" Enabled="false" runat="server" request></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Date Of Birth: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" CssClass="inputinput" request placeholder="yyyy/mm/dd"
                                runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Phone: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" CssClass="inputinput" request runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Address: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" CssClass="inputinput" request runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Gender: </b></p>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGender" CssClass="inputinput" runat="server">
                                <asp:ListItem Value="True">Male</asp:ListItem>
                                <asp:ListItem Value="False">Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-bottom: 20px">
                            <asp:Button CssClass="btn btn-primary center" ID="btnEdit" OnClick="btnEdit_Click"
                                runat="server" Text="Save" />
                            <asp:Button CssClass="btn btn-primary center" ID="cancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
                <table id="changePass" style="margin: 0 auto; display: none">
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>Old Pass: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOldPass" TextMode="Password" CssClass="inputinput" runat="server" request></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px">
                            <p><b>New Pass: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPass" TextMode="Password" CssClass="inputinput" runat="server" request></asp:TextBox></td>
                    </tr>
                   <tr>
                        <td style="padding-right: 50px">
                            <p><b>Comfirm New Pass: </b></p>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComfirm" TextMode="Password" CssClass="inputinput" runat="server" request></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-bottom: 20px">
                            <asp:Button CssClass="btn btn-primary center" ID="btnChangePass" OnClick="btnChangePass_Click"
                                runat="server" Text="Save" />
                            <asp:Button CssClass="btn btn-primary center" ID="cancel2" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--/blog-post-area-->
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <div class="features_items">
            <!--features_items-->
            <h2 class="title text-center">Order History</h2>
            <asp:Repeater ID="RepeaterHistory" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>OrderId</th>
                                <th>OrderDate</th>
                                <th>Total Amount</th>
                                <th>Received Date</th>
                                <th>Status</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center"><%# Eval("OrderId") %></td>
                        <td class="center"><%# Eval("OrderDate.Day") %>/<%# Eval("OrderDate.Month") %>/<%# Eval("OrderDate.Year") %></td>
                        <td class="center"><%# Eval("TotalAmount") %></td>
                        <td class="center"><%# Eval("ReceivedDate.Day") %>/<%# Eval("ReceivedDate.Month") %>/<%# Eval("ReceivedDate.Year") %></td>
                        <td class="center">
                            <a class="label label-success" href="#<%# Eval("OrderId") %>"><%# int.Parse(Eval("Status").ToString()) == 1 ?"Complete":"" %></a>
                            <a class="label label-warning" href="#<%# Eval("OrderId") %>"><%# int.Parse(Eval("Status").ToString()) == 2?"Waiting":"" %></a>
                            <a  class="label label-danger" ><%# int.Parse(Eval("Status").ToString()) == 4?"can cancel":"" %></a>                               
                        </td>
                        <td class="center">
                            <asp:LinkButton ID="lblCancel" OnClick="lblCancel_Click" CommandArgument='<%# Eval("OrderId") %>' CssClass="label label-danger" runat="server"><%# int.Parse(Eval("Status").ToString()) == 4?"Cancel":"" %></asp:LinkButton>
                            <a title="Details" href='#'>
                                <a href='DetailHistory.aspx?idorder=<%# Eval("OrderId") %>' class="label label-success">Details</a>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
			</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--features_items-->

        <!--/category-tab-->

</asp:Content>

