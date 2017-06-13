<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Backend_ChangPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" Runat="Server">
    
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">ChangPass</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form ChangePass</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form id="Form1" runat="server">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">Old Password</label>
                            <div class="controls">
                                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="span6 typeahead" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label"  for="typeahead">New Password</label>
                            <div class="controls">
                                <asp:TextBox ID="txtNewPass" TextMode="Password" CssClass="span6 typeahead" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">Comfirm New Password</label>
                            <div class="controls">
                                <asp:TextBox ID="txtComfirmPass"  TextMode="Password" CssClass="span6 typeahead" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-actions">
                            <%--<button type="submit" class="btn btn-primary">Save changes</button>--%>
                            <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" runat="server" Text="Save" />
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>

