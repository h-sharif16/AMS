<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="AMS.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>AMS</title>

    <!-- Bootstrap -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="~/AmsStyle/PublicStyle.css" rel="stylesheet"/>
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries <link href="PublicStyle.css" rel="stylesheet"/>-->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script><link href="PublicStyle.css" rel="stylesheet"/>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->  
     <%--hasan sharif--%>
    <script src="AmsScript/jquery-3.2.1.js"></script>
  

</head>
<body>

<form id="registrationForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="container-fluid noPaidding signupSininPageBg">
        <!-- Heaer Div -->
        <div class="container-fluid noPaidding headerBackground" style="min-height: 57px;">
            <div class="row noPaidding" style="line-height: 1.22">
                <!--Header part-1 for logo, sologan, image,contact info etc-->
                <div class="col-lg-11 col-md-11 noPaidding" style="min-height: 57px;">
                    <div class="row noPaidding sologan">
                        <div class="col-lg-3">
                        </div>
                        <div class="col-lg-6" style="margin-top: 0px;">
                            <span class="text-center text-success text-center heaerName">Apartment Management System (AMS) </span>
                            <span class="text-center text-info" style="color: #ffffff; padding-left: 20%;"><span class="glyphicon glyphicon-envelope">info@pentasoftbd.com</span></span>
                        </div>

                    </div>
                </div>
                <!--Header part-2 for SignUp, Signin Button-->
                <div class="col-lg-1 col-md-1 noPaidding" style="min-height: 77px;">
                    <div class="row noPaidding">
                    </div>
                    <div class="col-lg-6 noPaidding">
                        <a href="Default.aspx" class="btn btn-default signupBtn">
                            <span class="glyphicon glyphicon-home"></span></a>
                    </div>
                </div>
            </div>
        </div>
        <!-- SignUp Div -->
        <div class="row noPaidding" style="line-height: 1.22;">
            <div class="col-lg-4 col-md-4 col-sm-12">
            </div>
            <!-- Div for signup form-->
            <div class="col-lg-4 col-md-4 col-sm-12" style="background-color: #ffffff; margin: 20px; min-height: 200px; padding: 20px;">
            
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" CssClass="label label-info" Text="New Password"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"/>
                            <div class="rfvStyle">

                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="Please input Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    </div>
                 <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Label ID="lblConfirmPassword" runat="server" CssClass="label label-info" Text="Confirm New Password"></asp:Label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"/>
                            <div class="rfvStyle">
                                <asp:CompareValidator ID="cfvConfirmPassword" runat="server" ErrorMessage="Must match with Password!" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" Operator="Equal" Type="String" Display="Dynamic"></asp:CompareValidator>
                            </div>
                        </div>

                    </div>

                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Button ID="btnReset" CssClass="col-lg-12 btn btn-success" runat="server" Text="Reset Password" OnClick="btnReset_Click" style="left: 0px; top: 0px"/>

                        </div>

                    </div>
                </div>
                <asp:Panel runat="server" ID="panelEmailSmsNotification" Visible="False">
                    <div class="row" style="margin-top: 20px">
                    <div class="col-lg-12">
                        <asp:Literal ID="ltrlEmailSmsNotification" runat="server"></asp:Literal>
                        
                    </div>
                   
                </div>
                </asp:Panel>
                 
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
            </div>
        </div>

    </div>

</form>

</body>
</html>