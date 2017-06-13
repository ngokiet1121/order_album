<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="EditBanner.aspx.cs" Inherits="Backend_Banner_EditBanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Edit Banner</a>
        </li>
    </ul>
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
            <form id="Form1" class="form-horizontal" runat="server">
               <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="selectError">Group Select</label>
                        <div class="controls">
                            <asp:DropDownList ID="ddlGroup" DataTextField="Name" DataValueField="GroupId" data-rel="chosen" runat="server">                             
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="fileInput">File input</label>
                        <div class="controls">
                            <asp:FileUpload ID="txtFileUpLoad" CssClass="input-file uniform_on" runat="server" />
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
</asp:Content>

