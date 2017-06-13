<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="EditAlbum.aspx.cs" Inherits="Backend_Album_EditAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="Backend/Index.aspx">Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Forms</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form Edit Album</h2>
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
                            <label class="control-label" for="focusedInput">Name Album</label>
                            <div class="controls">
                                <asp:TextBox ID="txtName" runat="server" CssClass="input-xlarge focused" required></asp:TextBox>                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Quantity Album</label>
                            <div class="controls">
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="input-xlarge focused" required></asp:TextBox>

                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">UnitPrice</label>
                            <div class="controls">
                                <asp:TextBox ID="txtUnitAlbum" runat="server" CssClass="input-xlarge focused" required></asp:TextBox> 
                            </div>
                        </div>

                         <div class="control-group">
                            <label class="control-label" for="date01">Publisher Date</label>
                            <div class="controls">
                                <asp:TextBox ID="txtPublishedDate" runat="server" CssClass="input-xlarge datepicker" required></asp:TextBox> 
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Entered Date Album</label>
                            <div class="controls">
                                <asp:TextBox ID="txtEnteredDate" runat="server" CssClass="input-xlarge datepicker" required></asp:TextBox>                           
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="fileInput">File input</label>
                            <div class="controls">
                                <asp:FileUpload ID="txtFileUpLoad" CssClass="input-file uniform_on" runat="server" />
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
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Producer</label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlProducer" DataTextField="Name" DataValueField="ProducerId" data-rel="chosen" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                       

                        <div class="control-group">
                            <label class="control-label" for="selectError1">Multiple Select / Tags</label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlTags" multiple data-rel="chosen" runat="server">
                                    <asp:ListItem>Option2</asp:ListItem>
                                    <asp:ListItem>Option3</asp:ListItem>
                                    <asp:ListItem>Option4</asp:ListItem>
                                    <asp:ListItem>Option5</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>
                        </div>
                        <div class="control-group hidden-phone">
                            <label class="control-label" for="textarea2">Description</label>
                            <div class="controls">
                                <asp:TextBox ID="textareaDescription" TextMode="MultiLine" CssClass="cleditor" runat="server"></asp:TextBox>
                                <%--<textarea class="cleditor" id="textarea2" rows="3"></textarea>--%>
                            </div>
                        </div>
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnEdit" CssClass="btn btn-primary" OnClick="btnEdit_Click" runat="server" Text="Save" />
                            <asp:Button ID="btnAddnew" CssClass="btn" OnClick="btnAddNew_Click" runat="server" Text="Add New" />
                            
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>

