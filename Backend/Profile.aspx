<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Backend_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
  <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="index.html">Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Edit Employee</a>
        </li>
    </ul>
     <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Edit Employee</h2>
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
                            <label class="control-label">Email</label>
                            <div class="controls">
                                <asp:TextBox ID="txtEmail" ReadOnly="true" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">FullName</label>
                            <div class="controls">
                                <asp:TextBox ID="txtName" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Phone</label>
                            <div class="controls">
                                <asp:TextBox ID="txtPhone" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Date Of Birth</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDOB" CssClass="input-xlarge datepicker" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Address</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAddress" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Gender</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem Value="True">Male</asp:ListItem>
                                    <asp:ListItem Value="False">Female</asp:ListItem>
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
                            <asp:Button ID="btnEdit" CssClass="btn btn-primary" OnClick="btnEdit_Click" runat="server" Text="Change" />                                             
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
        <!--/span-->

    </div>
</asp:Content>

