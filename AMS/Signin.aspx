﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="AMS.Signin" %>

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
    <script src="AmsScript/jquery-3.2.1.js"></script>


    <link href="AmsStyle/ValidationEngine.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="AmsScript/jquery1.8.3.min.js"></script>
    <script type="text/javascript" src="AmsScript/jquery.validationEngine-en.js"
            charset="utf-8"></script>
    <script type="text/javascript" src="AmsScript/jquery.validationEngine.js"
            charset="utf-8"></script>
    <script type="text/javascript">
        $(function() {
            $("#signinForm").validationEngine('attach', { promptPosition: "topRight" });
        });
    </script>
    <script type="text/javascript">
        function DateFormat(field, rules, i, options) {
            var regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
            if (!regex.test(field.val())) {
                return "Please enter date in dd/MM/yyyy format.";
            }
        };

        function EmailorMobileReqMsg() {


            return "Please enter a valid Email or a Mobile Number.";

        };

    </script>
</head>
<body>

<form id="signinForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="container-fluid noPaidding signupSininPageBg">
        <!-- Heaer Div -->
        <div class="container-fluid noPaidding headerBackground" style="min-height: 57px">
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


                            <%--validate[required,funcCall[EmailorMobileReqMsg]--%>
                            <asp:Label ID="lblEMail" runat="server" CssClass="label label-info" Text="Email / Mobile Number"></asp:Label>
                            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control validate[required]"/>


                            <asp:RequiredFieldValidator ID="rfvUserId" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtUserId" ForeColor="red"></asp:RequiredFieldValidator>


                        </div>

                    </div>

                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group" style="margin-bottom: 0px">
                            <asp:Label ID="lblPassword" runat="server" CssClass="label label-info" Text="Password"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control validate[required]" TextMode="Password"/>&nbsp;


                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>

                        </div>

                    </div>


                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="checkbox-inline" Text="Remember Me for 7 days " TextAlign="Right" style="color: #404753; font-family: sans-serif; font-size: 9pt; font-weight: normal;"/>

                        </div>

                    </div>


                </div>
              
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Button ID="btnSignin" CssClass="col-lg-12 btn btn-success" runat="server" Text="sign in" OnClick="btnSignin_Click"/>

                        </div>

                    </div>
                </div>
                 <asp:Panel runat="server" ID="panelLoginErrorMessage" Visible="False">
                    <div class="row" style="margin-top: 20px">
                    <div class="col-lg-12">
                        
                        <asp:Label ID="lblLoginErrorMessage" runat="server" ForeColor="Red" Text="Invalid Login. Please try again." CssClass="bg-danger"></asp:Label>
                       
                       
                        
                    </div>
                   
                </div>
                </asp:Panel>
                <div class="row" style="margin-top: 20px">
                    <div class="col-lg-6">
                        <span  class="text-green" > <a href="Signup.aspx" >create account></a></span>

                    </div>
                    <div class="col-lg-6" style="text-align: right">
                      <%--  <span > <a href="ForgotPassword.aspx" ><span><</span>forgot password</a></span>--%>
                         <span class="glyphicon glyphicon-wrench"></span><a href="PasswordRetriveLink.aspx"> I Forgot My Password!</a>  
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
            </div>
        </div>

    </div>

</form>

</body>
</html>
