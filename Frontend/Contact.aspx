<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Frontend_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
        <div id="contact-page" class="container">
    	<div class="bg">
	    	<div class="row">    		
	    		<div class="col-sm-12">    			   			
					<h2 class="title text-center">Contact <strong>Us</strong></h2>    			    				    				
					<div id="gmap" class="contact-map">                        
                        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d26081603.294420466!2d-95.677068!3d37.06250000000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1svi!2s!4v1466323552931" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
					</div>
				</div>			 		
			</div>    	
    		<div class="row">  	
	    		<div class="col-sm-8">
	    			<div class="contact-form">
	    				<h2 class="title text-center">Get In Touch</h2>
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<div id="main-contact-form" class="contact-form row">
				            <div class="form-group col-md-6">
                                 <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" required runat="server"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-6">
                                 <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="Email" runat="server" required></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtSubjeck" CssClass="form-control" placeholder="Subject" required runat="server"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
                                <asp:TextBox ID="txtMessage" TextMode="MultiLine" style="height:150px" CssClass="form-control" rows="8" required placeholder="Your Message Here" runat="server"></asp:TextBox>
				            </div>
                             <div class="success" >
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                             </div>                       
				            <div class="form-group col-md-12">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary pull-right" Text="Send Mail" />
				            </div>
				        </div>
	    			</div>
	    		</div>
	    		<div class="col-sm-4">
	    			<div class="contact-info">
	    				<h2 class="title text-center">Contact Info</h2>
	    				<address>
	    					<p>Order Album Inc.</p>
    						<p>15 Quang Trung</p>
							
							<p>Mobile: +0987654321</p>							
							<p>Email: OrderAlbum@gmail.com</p>
	    				</address>
	    				<div class="social-networks">
	    					<h2 class="title text-center">Social Networking</h2>
							<ul>
								<li>
									<a href="#"><i class="fa fa-facebook"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-twitter"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-google-plus"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-youtube"></i></a>
								</li>
							</ul>
	    				</div>
	    			</div>
    			</div>    			
	    	</div>  
    	</div>	
    </div><!--/#contact-page-->
	
</asp:Content>

