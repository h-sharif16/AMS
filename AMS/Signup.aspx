<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="AMS.Signup" %>

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
    <script type="text/javascript">
        function IsEmailOrMobileNOInpute(source, args) {

            if (args.Value
                .trim() ==
                "" &&
                (document.getElementById('<%= txtMobileNo.ClientID %>').value.trim() == "")) {
                args.IsValid = false;

            } else {
                args.IsValid = true;
            }
        }

        $(document)
            .ready(function() {

                $("#<%= txtEmail.ClientID %>")
                    .blur(function() {

                        var searchString = $(this).val();
                        //alert(searchString);
                        if (searchString.length >= 3) {

                            $.ajax({
                                url: 'Common/CheckAvailabilityService.asmx/CheckAvailabitity',
                                method: 'post',
                                data: { SearchString: searchString, TableName: 'ams.Users', TableColumn: 'Email' },
                                dataType: 'json',
                                timeout: 3000,
                                success: function(data) {
                                    var divElement = $('#ajaxEmailOutput');
                                    if (data.ValueExists) {
                                        divElement.text('This Email is already Exists');
                                        divElement.css('margin-top', '1px');
                                        divElement.css('background-color', '#F9E5E5');
                                        divElement.css('color', '#DF7BA5');
                                        divElement.css('font-size', '10pt');
                                        divElement.css('font-family', 'Avenir, sans-serif');

                                    } else {
                                        divElement.text('This Email is available');
                                        divElement.css('margin-top', '1px');
                                        divElement.css('background-color', '#F9E5E5');
                                        divElement.css('color', 'green');
                                        divElement.css('font-size', '10pt');
                                        divElement.css('font-family', 'Avenir, sans-serif');
                                    }
                                },
                                error: function(err) {
                                    alert(err);
                                }

                            });
                        } else {
                            var divElement = $('#divOutput');
                            divElement.empty();
                            divElement.visible = false;
                        }
                    });

                $("#<%= txtMobileNo.ClientID %>")
                    .blur(function() {

                        var searchString = $(this).val();
                        //alert(searchString);
                        if (searchString.length >= 3) {
                            $.ajax({
                                url: 'Common/CheckAvailabilityService.asmx/CheckAvailabitity',
                                method: 'post',
                                data: { SearchString: searchString, TableName: 'ams.Users', TableColumn: 'MobileNo' },
                                dataType: 'json',
                                timeout: 3000,
                                success: function(data) {
                                    var divElement = $('#ajaxMobileOutput');

                                    if (data.ValueExists) {
                                        divElement.text(searchString + ' is already Exists');
                                        divElement.css('margin-top', '1px');
                                        divElement.css('background-color', '#F9E5E5');
                                        divElement.css('color', '#DF7BA5');
                                        divElement.css('font-size', '10pt');
                                        divElement.css('font-family', 'Avenir, sans-serif');
                                    } else {
                                        divElement.text(searchString + ' is available');
                                        divElement.css('margin-top', '1px');
                                        divElement.css('background-color', '#F9E5E5');
                                        divElement.css('color', 'green');
                                        divElement.css('font-size', '10pt');
                                        divElement.css('font-family', 'Avenir, sans-serif');
                                    }
                                },
                                error: function(err) {
                                    alert(err);
                                }

                            });
                        } else {
                            var divElement = $('#divOutput');
                            divElement.empty();
                            divElement.visible = false;
                        }
                    });
            });

        $(function() {
            $(".Validators").Float();
        });
    </script>

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
                            <asp:Label ID="lblAccountType" runat="server" CssClass="label label-info" Text="Select Account Type"></asp:Label>
                            <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Select a Account Type</asp:ListItem>
                                <asp:ListItem Value="L">Landlord</asp:ListItem>
                                <asp:ListItem Value="T">Tenant</asp:ListItem>
                                <asp:ListItem Value="A">Service Provider</asp:ListItem>
                            </asp:DropDownList>
                            <div class="rfvStyle">

                                <asp:RequiredFieldValidator ID="rfvAccountType" runat="server" Display="Dynamic" ErrorMessage="Required Field" ControlToValidate="ddlAccountType" InitialValue=""></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <%--<div class="col-lg-12" style="background-color: #F9E5E5; margin: 1px; font-family: Avenir, sans-serif; font-size: 8pt;color: #DF7BA5 " >
                           
                        </div>--%>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblFirstName" runat="server" CssClass="label label-info" Text="First Name"></asp:Label>

                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"/>
                            <div class="rfvStyle">

                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="Dynamic" ErrorMessage="Please input your First Name" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblLastName" runat="server" CssClass="label label-info" Text="Last Name"></asp:Label>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"/>
                            <div class="rfvStyle">

                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" Display="Dynamic" ErrorMessage="Please input your Last Name" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:UpdatePanel runat="server" ID="emailUpdatepanel">
                                <ContentTemplate>
                                    <asp:Label ID="lblEMail" runat="server" CssClass="label label-info" Text="Email"></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"/>
                                    <div id="ajaxEmailOutput"></div>
                                    <div class="rfvStyle">

                                        <asp:RegularExpressionValidator ID="refvEmail" runat="server" Display="Dynamic" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblMobileNo" runat="server" CssClass="label label-info" Text="Mobile Number"></asp:Label>
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" MaxLength="11"/>
                            <div id="ajaxMobileOutput"></div>
                            <div class="rfvStyle">
                                <asp:RegularExpressionValidator ID="refvMobileNo" runat="server"
                                                                ControlToValidate="txtMobileNo" ErrorMessage="Mobile Number is not valid."
                                                                ValidationExpression="[0-9]{11}" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group" style="margin: 0px 0px 2px 0px; padding: 0">
                            <div class="rfvStyle">

                                <asp:CustomValidator ID="cusfvEmailMobileNo" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="To Sign up you have to input either Email or Mobile Number." OnServerValidate="cusfvEmailMobileNo_ServerValidate" ClientValidationFunction="IsEmailOrMobileNOInpute" ValidateEmptyText="True"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" CssClass="label label-info" Text="Password"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"/>
                            <div class="rfvStyle">

                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="Please input Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblConfirmPassword" runat="server" CssClass="label label-info" Text="Confirm Password"></asp:Label>
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
                            <asp:Button ID="btnSignup" CssClass="col-lg-12 btn btn-success" runat="server" Text="sign up" OnClick="btnSignup_Click" style="left: 0px; top: 0px"/>

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
                <div class="row" style="margin-top: 20px">
                    <div class="col-lg-5">
                        <span  class="text-green" > <a href="Signin.aspx" >Sign in></a></span>

                    </div>
                    <div class="col-lg-7" style="text-align: right">
                        <span >  You agree to our  <a href="TermsOfUse.aspx" >terms of use > </a></span>

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