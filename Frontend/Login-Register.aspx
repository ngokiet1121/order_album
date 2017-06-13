<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="Login-Register.aspx.cs" Inherits="Frontend_Login_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <section id="form">
        <!--form-->
        <div class="container">
            <div class="row">
                <div class="col-sm-4 col-sm-offset-1">
                    <div class="login-form">
                        <!--login form-->
                        <h2>Login to your account</h2>
                       <fieldset>
                        <div class="control-group">
                            <div class="controls">
                                <asp:TextBox ID="txtEmail" CssClass="span6 typeahead" TextMode="Email"  placeholder="Email" data-provide="typeahead" data-items="4" runat="server" ></asp:TextBox>                             
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:TextBox ID="txtPassword" CssClass="span6 typeahead" TextMode="Password" placeholder="Password" data-provide="typeahead" data-items="4" runat="server" ></asp:TextBox>                             
                            </div>
                        </div>
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-actions">
                           <asp:Button ID="btnLogin" CssClass="btn btn-primary"
                                runat="server" Text="Login" OnClick="btnLogin_Click"/>
                        </div></br>
                        <a href="ResetPass.aspx">Forget password? Click here.</a></br>
                        <a href="register.aspx">New user? Signup here.</a>
                         </fieldset>
                    </div>
                    <!--/login form-->
                </div>
               <%--  <div class="col-sm-1">
                    <h2 class="or">OR</h2>
                </div>
               <div class="col-sm-4">
                    <div class="signup-form">
                        <!--sign up form-->
                        <h2>New User Signup!</h2>
                        <fieldset>
                        <div class="control-group">
                            <div class="controls">
                                <asp:TextBox ID="txtFullName" placeholder="Full Name" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:TextBox ID="txtRegisterEmail" placeholder="Email" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:TextBox ID="txtRegisterPassword" placeholder="Password" CssClass="input-xlarge focused" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:TextBox ID="txtPhone" CssClass="input-xlarge focused" placeholder="Phone" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:TextBox ID="txtDOB" CssClass="input-xlarge datepicker" TextMode="Date" placeholder="Date Of Birth (dd/mm/yyyy)" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:TextBox ID="txtAddress" CssClass="input-xlarge focused" placeholder="Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">

                            <div class="controls">
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem >Gender</asp:ListItem>
                                    <asp:ListItem Value="true">Male</asp:ListItem>
                                    <asp:ListItem Value="false">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>                                            
                        <div class="form-actions">
                            <asp:Button ID="btnSignup" CssClass="btn btn-primary"  runat="server" Text="Register" />
                        </div>
                    </fieldset>
                    </div>
                    <!--/sign up form-->
                </div>--%>
            </div>
        </div>
    </section>
    <!--/form-->
</asp:Content>

