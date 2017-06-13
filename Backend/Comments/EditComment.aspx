<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="EditComment.aspx.cs" Inherits="Backend_Comments_EditComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
             <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Edit Comments</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form Edit Comments</h2>
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
                            <label class="control-label">Customer Email</label>
                            <div class="controls">
                                <asp:TextBox ID="txtEmail" ReadOnly="true" CssClass="input-xlarge uneditable-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Album</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlAlbum" runat="server" 
                                DataTextField="Name" DataValueField="AlbumId" data-rel="chosen" >
                                </asp:DropDownList>
                                
                            </div>
                        </div>
                       <div class="control-group hidden-phone">
							  <label class="control-label" for="textarea2">Description</label>
							  <div class="controls">
                                   <asp:TextBox ID="txtContent" ReadOnly="true" CssClass="cleditor" TextMode="MultiLine" runat="server"></asp:TextBox>
							  </div>
						</div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Status Select</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem Value="1">Enabled</asp:ListItem>
                                    <asp:ListItem Value="2">Disabled</asp:ListItem>
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
                            <asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" CssClass="btn btn-primary" runat="server" Text="Edit" />
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

