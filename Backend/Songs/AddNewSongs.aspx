<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="AddNewSongs.aspx.cs" Inherits="Backend_Songs_AddNewSongs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
             <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Add New Songs</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Add New Song</h2>
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
                            <label class="control-label" for="focusedInput">Name Song</label>
                            <div class="controls">
                                <asp:TextBox ID="txtSong" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                                  </div>
                        </div> 
                        <div class="control-group">
                            <label class="control-label" for="focusedInput">Author</label>
                            <div class="controls">
                               <asp:TextBox ID="txtAuthor" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                                </div>
                        </div>                     
                        <div class="control-group">
                            <label class="control-label" for="selectError">Album Select</label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlAlbum" DataTextField="Name" DataValueField="AlbumId"   data-rel="chosen" runat="server">
                                </asp:DropDownList>   
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError">Group Select</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlGroup" DataTextField="Name" DataValueField="GroupId"  data-rel="chosen" runat="server">
                                </asp:DropDownList>   
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError">Genres Select</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlGenres" DataTextField="Name" DataValueField="GenresId"  data-rel="chosen" runat="server">
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
                            <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" runat="server" Text="Save changes" />
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

