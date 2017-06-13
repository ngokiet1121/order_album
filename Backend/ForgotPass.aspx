<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPass.aspx.cs" Inherits="Backend_Login" %>

<!DOCTYPE html>

<html lang="en">
<head>

    <!-- start: Meta -->
    <meta charset="utf-8">
    <title>Manager</title>
    <meta name="description" content="Bootstrap Metro Dashboard">
    <meta name="author" content="Dennis Ji">
    <meta name="keyword" content="Metro, Metro UI, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <!-- end: Meta -->

    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- end: Mobile Specific -->

    <!-- start: CSS -->
    <link href="Common/css/bootstrap.min.css" rel="stylesheet">
    <link href="Common/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="Common/css/style.css" rel="stylesheet">
    <link href="Common/css/style-responsive.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext' rel='stylesheet' type='text/css'>
    <!-- end: CSS -->


    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link id="ie-style" href="css/ie.css" rel="stylesheet">
	<![endif]-->

    <!--[if IE 9]>
		<link id="ie9style" href="css/ie9.css" rel="stylesheet">
	<![endif]-->

    <!-- start: Favicon -->
    <link rel="shortcut icon" href="img/favicon.ico">
    <!-- end: Favicon -->

    <style type="text/css">
        body {
            background: url(../Images/imgadmin/bg-login.jpg) !important;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("a").click(function () {
                $("#login").toggle(1000);
                $("#forgot").toggle(1000);
            });
        });
    </script>
</head>

<body>
    <div class="container-fluid-full">
        <div class="row-fluid">
            <div class="row-fluid">
                <h1 style="text-align: center; margin-top: 100px;">Order Album</h1>
                <div class="login-box">
                    <form runat="server" class="form-horizontal">
                        <div id="login">
                            <h2 id="h21">Forgot Password</h2>
                            <fieldset>
                                <div class="input-prepend" id="Div1" title="Username">
                                    <span class="add-on"><i class="halflings-icon user"></i></span>
                                    <asp:TextBox ID="txtEmail" CssClass="input-large span10" TextMode="Email" runat="server" required></asp:TextBox>
                                    <%--                                    <input class="input-large span10" name="email" id="email1" type="email" placeholder="type username" required />--%>
                                </div>
                                <div class="clearfix"></div>
                                <div class="alert-danger">
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="alert-success">
                                    <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                                </div>
                                <hr>
                                <h3><a href="Login.aspx">Login</a></h3>
                                 </fieldset>
                        </div>
                        <div class="button-login">
                            <asp:Button ID="btnForgot" CssClass="btn btn-primary"  OnClick="btnForgot_Click" runat="server" Text="Forgot" />
                        </div>
                        <div class="clearfix"></div>
                    </form>
                    <hr>
                </div>
                <!--/span-->
            </div>
            <!--/row-->

        </div>
        <!--/.fluid-container-->

    </div>
    <!--/fluid-row-->
    <div class="common-modal modal fade" id="common-Modal1" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-content">
            <ul class="list-inline item-details">
                <li><a href="http://themifycloud.com">Admin templates</a></li>
                <li><a href="http://themescloud.org">Bootstrap themes</a></li>
            </ul>
        </div>
    </div>
    <!-- start: JavaScript-->

    <script src="../../Scripts/js/jquery-1.9.1.min.js"></script>
    <script src="../../Scripts/js/jquery-migrate-1.0.0.min.js"></script>

    <script src="../../Scripts/js/jquery-ui-1.10.0.custom.min.js"></script>

    <script src="../../Scripts/js/jquery.ui.touch-punch.js"></script>

    <script src="../../Scripts/js/modernizr.js"></script>

    <script src="../../Scripts/js/bootstrap.min.js"></script>

    <script src="../../Scripts/js/jquery.cookie.js"></script>

    <script src='../../Scripts/js/fullcalendar.min.js'></script>

    <script src='../../Scripts/js/jquery.dataTables.min.js'></script>

    <script src="../../Scripts/js/excanvas.js"></script>
    <script src="../../Scripts/js/jquery.flot.js"></script>
    <script src="../../Scripts/js/jquery.flot.pie.js"></script>
    <script src="../../Scripts/js/jquery.flot.stack.js"></script>
    <script src="../../Scripts/js/jquery.flot.resize.min.js"></script>

    <script src="../../Scripts/js/jquery.chosen.min.js"></script>

    <script src="../../Scripts/js/jquery.uniform.min.js"></script>

    <script src="../../Scripts/js/jquery.cleditor.min.js"></script>

    <script src="../../Scripts/js/jquery.noty.js"></script>

    <script src="../../Scripts/js/jquery.elfinder.min.js"></script>

    <script src="../../Scripts/js/jquery.raty.min.js"></script>

    <script src="../../Scripts/js/jquery.iphone.toggle.js"></script>

    <script src="../../Scripts/js/jquery.uploadify-3.1.min.js"></script>

    <script src="../../Scripts/js/jquery.gritter.min.js"></script>

    <script src="../../Scripts/js/jquery.imagesloaded.js"></script>

    <script src="../../Scripts/js/jquery.masonry.min.js"></script>

    <script src="../../Scripts/js/jquery.knob.modified.js"></script>

    <script src="../../Scripts/js/jquery.sparkline.min.js"></script>

    <script src="../../Scripts/js/counter.js"></script>

    <script src="../../Scripts/js/retina.js"></script>

    <script src="../../Scripts/js/custom.js"></script>
    <!-- end: JavaScript-->

</body>
</html>
