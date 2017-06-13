<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="AddNewSinger.aspx.cs" Inherits="Backend_Singers_AddNewSinger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Add New Singer</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Add new singer</h2>
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
                            <label class="control-label" for="focusedInput">Code Singer</label>
                            <div class="controls">
                                <asp:TextBox ID="txtIdSinger" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Name Singer</label>
                            <div class="controls">
                                <asp:TextBox ID="txtName" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="date01">Date Of Birth</label>
                            <div class="controls">
                                 <asp:TextBox ID="txtDOB" CssClass="input-xlarge datepicker" runat="server"></asp:TextBox>                             
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">Gender</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem Value="true">Male</asp:ListItem>
                                    <asp:ListItem Value="false">Female</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="fileInput">File input</label>
                            <div class="controls">
                                <asp:FileUpload ID="txtImage" CssClass="input-file uniform_on" runat="server" />
                            </div>
                        </div>                                              
                        <div class="control-group">
                            <label class="control-label" for="selectError">Select Group</label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlGroup" DataTextField="Name" DataValueField="GroupId" 
                                      data-rel="chosen" runat="server">
                                   
                                </asp:DropDownList>                          
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError">Select Nationality</label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlNationality" DataTextField="Name" DataValueField="NationalityId" 
                                      data-rel="chosen" runat="server">
                                   
                                </asp:DropDownList>                          
                            </div>
                        </div>                  
                        <div class="control-group hidden-phone">
                            <label class="control-label" for="textarea2">Description</label>
                            <div class="controls">
                                 <asp:TextBox ID="txtDescription" CssClass="cleditor" TextMode="MultiLine" runat="server"></asp:TextBox>                             
                            </div>
                        </div>
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-actions">
                             <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" runat="server" Text="Save" />
                            <button class="btn">Cancel</button>
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>

