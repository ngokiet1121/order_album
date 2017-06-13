<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="AddMadeIn.aspx.cs" Inherits="Backend_MadeIn_AddMadeIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" runat="Server">
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <i class="icon-edit"></i>
            <a href="#">Add Producers</a>
        </li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Form Producers</h2>
                <div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon white wrench"></i></a>
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                    <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form runat="server" class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">Name</label>
                            <div class="controls">
                                <asp:TextBox ID="txtName" CssClass="span6 typeahead" data-provide="typeahead" data-items="4" runat="server"></asp:TextBox>
                                <%--<input type="text" class="span6 typeahead" id="Text2" data-provide="typeahead" data-items="4" />--%>
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

