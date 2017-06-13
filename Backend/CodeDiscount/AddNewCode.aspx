<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="AddNewCode.aspx.cs" Inherits="Backend_CodeDiscount_AddNewCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Add Code Sale</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form Elements</h2>
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
                            <label class="control-label" for="date01">Date Begin</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDateBegin" runat="server" CssClass="input-xlarge datepicker" required></asp:TextBox> 
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="date01">Date End</label>
                            <div class="controls">
                               <asp:TextBox ID="txtDateEnd" runat="server" CssClass="input-xlarge datepicker" required></asp:TextBox> 
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Code</label>
                            <div class="controls">
                                <asp:TextBox ID="txtCode" runat="server" CssClass="input-xlarge focused" required></asp:TextBox>                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Percent Sale</label>
                            <div class="controls">
                                <asp:TextBox ID="txtPercent" runat="server" CssClass="input-xlarge focused" required></asp:TextBox>                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Status Album</label>
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
                           <asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" CssClass="btn btn-primary" runat="server" Text="Add" />
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

