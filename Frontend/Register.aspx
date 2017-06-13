<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/NoLeft.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Frontend_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <section id="form">
        <!--form-->
        <div class="container">
            <div class="row">
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
                        <div class="alert-danger">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="alert-success">
                            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                        </div>                                       
                        <div class="form-actions">
                            <asp:Button ID="btnSignup" CssClass="btn btn-primary" 
                                 runat="server" Text="Register" OnClick="btnSignup_Click"/>
                        </div>
                    </fieldset>
                    </div>
                    <!--/sign up form-->
                </div>
            </div>
        </div>
    </section>
    <!--/form-->
</asp:Content>

