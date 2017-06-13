<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Common/Backend.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Backend_Messages_FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentAdmin" Runat="Server">
    <ul class="breadcrumb">
				<li>
					 <i class="icon-home"></i>
            <a href='<%= ResolveUrl("~/Backend")%>/Index.aspx'>Home</a>
            <i class="icon-angle-right"></i>
				</li>
				<li>
					<i class="icon-edit"></i>
					<a href="#">FeedBack</a>
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
							  <label class="control-label" for="typeahead">Customer Email</label>
							  <div class="controls">
                                <asp:TextBox ID="txtCustomerEmail" Enabled="false" CssClass="span6 typeahead" runat="server"></asp:TextBox>							
							  </div>
							</div>
							<div class="control-group">
							  <label class="control-label" for="typeahead">SubJect</label>
							  <div class="controls">
                                <asp:TextBox ID="txtSubJect" CssClass="span6 typeahead" runat="server"></asp:TextBox>							
							  </div>
							</div>         
							<div class="control-group hidden-phone">
							  <label class="control-label" for="textarea2">Textarea Body</label>
							  <div class="controls">
                                <asp:TextBox ID="textarea2" CssClass="cleditor" TextMode="MultiLine" runat="server"></asp:TextBox>
							  </div>
							</div>
                              <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> 
							<div class="form-actions">
                                <asp:Button ID="btnSend" CssClass="btn btn-primary" OnClick="btnSend_Click" runat="server" Text="SendMail" />							  
							</div>
						  </fieldset>
						</form>                          
					</div>
				</div><!--/span-->

			</div><!--/row-->
</asp:Content>

