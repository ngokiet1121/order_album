<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="EditCustomer.aspx.cs" Inherits="Backend_Customer_EditCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
           <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Edit Customer</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form Edit Customer</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label"> Email</label>
                            <div class="controls">
                                <asp:TextBox ID="txtEmail" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Name</label>
                            <div class="controls">
                                <asp:TextBox ID="txtName" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Address</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAddress" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Phone</label>
                            <div class="controls">
                                <asp:TextBox ID="txtPhone" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Date Of Birth</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDateOfBirth" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Register Day</label>
                            <div class="controls">
                                <asp:TextBox ID="txtRegisteredDate" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"> Gender</label>
                            <div class="controls">
                                <asp:TextBox ID="txtGender" Enabled="false" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Status Select</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">Banned</asp:ListItem>
                                    <asp:ListItem Value="3">Pending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div> 
                        <div class="form-actions">
                            <asp:Button ID="btnEdit" CssClass="btn btn-primary" OnClick="btnEdit_Click" runat="server" Text="Edit" />
                            <asp:Button ID="Button1" CssClass="btn" runat="server" Text="Cancel" />                        
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>

