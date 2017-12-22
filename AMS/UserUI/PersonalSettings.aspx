<%@ Page Title="" Language="C#" MasterPageFile="~/UserUI/Users.Master" AutoEventWireup="true" CodeBehind="PersonalSettings.aspx.cs" Inherits="AMS.UserUI.PersonalSettings" EnableEventValidation="false" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.5.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--   <asp:ToolkitScriptManager runat="server" ID="toolScriptManageer1" ></asp:ToolkitScriptManager>--%>
    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            width: 24.4%;
            float: left;
            margin: 20px 5px 30px 0px;
            /*background: url("../UserUI/img/InitialImage.png") no-repeat right top;*/
            background-color: darkcyan;
            color: white;
            font-weight: bold;
        }

            .Initial:hover {
                color: darkblue;
                /*background: url("../UserUI/img/SelectedButton.png") no-repeat right top;*/
                background-color: cornflowerblue;
                margin: 20px 5px 30px 0px;
            }

        .Clicked {
            float: left;
            display: block;
            /*background: url("../UserUI/img/SelectedButton.png") no-repeat right top;*/
            background-color: cornflowerblue;
            padding: 4px 18px 4px 18px;
            margin: 20px 5px 30px 0px;
            color: white;
            font-weight: bold;
            color: White;
            width: 24.4%;
        }

        .auto-style1 {
            display: block;
            width: 100%;
            font-size: 1rem;
            line-height: 1.25;
            color: #464a4c;
            -webkit-background-clip: padding-box;
            background-clip: padding-box;
            border-radius: 0;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #e6e6e6;
            margin-bottom: 0;
            padding: 10px 15px;
            background-color: #fff;
            background-image: none;
        }
    </style>
    <div class="container" style="margin: auto">

        <div class="row noPaidding">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="updatePanelTab">
                    <ContentTemplate>
                        <asp:Button Text="Generl Information" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" OnClick="Tab1_Click" />
                        <asp:Button Text="Contact Information" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                            OnClick="Tab2_Click" />
                        <asp:Button Text="Account Settings" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
                            OnClick="Tab3_Click" />
                        <asp:Button Text="Login Iformation" BorderStyle="None" ID="Tab4" CssClass="Initial" runat="server" OnClick="Tab4_Click" />


                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto">
                                                    <h5>General Information
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="line-height: 1.22; margin: auto">
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: 20px; min-height: 200px; padding: 20px; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblFirstName" runat="server" CssClass="label label-info" Text="First Name"></asp:Label>

                                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2"></div>
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblMiddleName" runat="server" CssClass="label label-info" Text="Middle Name"></asp:Label>

                                                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblLastName" runat="server" CssClass="label label-info" Text="Last Name"></asp:Label>

                                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2"></div>
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblEmail" runat="server" CssClass="label label-info" Text="Email"></asp:Label>

                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblNID" runat="server" CssClass="label label-info" Text="National ID"></asp:Label>

                                                                <asp:TextBox ID="txtNID" runat="server" CssClass="form-control"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2"></div>
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblTIN" runat="server" CssClass="label label-info" Text="TIN Number"></asp:Label>

                                                                <asp:TextBox ID="txtTIN" runat="server" CssClass="form-control"></asp:TextBox>


                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblProfession" runat="server" CssClass="label label-info" Text="Select Profession"></asp:Label>

                                                                <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control" AutoPostBack="True" DataTextField="DataText" DataValueField="DataValue" OnSelectedIndexChanged="ddlProfession_SelectedIndexChanged"></asp:DropDownList>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2"></div>

                                                        <div class="col-lg-5">

                                                            <div class="form-group">
                                                                <asp:Label ID="lblDateOfBirth" runat="server" CssClass="label label-info" Text="Date Of Birth"></asp:Label>
                                                                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <%--     <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth" Format="dd-MMM-yyyy"></asp:CalendarExtender>--%>

                                                                <%-- <asp:CalendarExtender ID="cexDOB" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtDateOfBirth" TodaysDateFormat="dd-MMM-yyyy"></asp:CalendarExtender>--%>
                                                            </div>

                                                        </div>

                                                    </div>
                                                    <asp:Panel runat="server" ID="panelOtherProfessionTextBox" Visible="False">
                                                        <div class="row">
                                                            <div class="col-lg-5">

                                                                <div class="form-group">
                                                                    <asp:Label ID="lblOthersProfession" runat="server" CssClass="label label-info" Text="Others Profession"></asp:Label>
                                                                    <asp:TextBox ID="txtOthersProfession" runat="server" CssClass="auto-style1"></asp:TextBox>


                                                                </div>


                                                            </div>
                                                            <div class="col-lg-2"></div>

                                                            <div class="col-lg-5">
                                                            </div>

                                                        </div>
                                                    </asp:Panel>
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblReligion" runat="server" CssClass="label label-info" Text="Select Religion"></asp:Label>

                                                                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control" DataTextField="DataText" DataValueField="DataValue"></asp:DropDownList>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2"></div>

                                                        <div class="col-lg-5  noPaidding">
                                                            <div class="form-group">
                                                                <div class="row noPaidding">
                                                                    <div class="col-lg-8">
                                                                        <asp:Label ID="lblPicture" runat="server" CssClass="label label-info" Text="Picture"></asp:Label>


                                                                        <asp:FileUpload ID="fudProfileImage" runat="server" CssClass="form-control" />
                                                                    </div>
                                                                    <div class="col-lg-4">
                                                                        <asp:Label ID="Label1" runat="server" CssClass="label" Text=""></asp:Label>
                                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="form-control" OnClick="btnUpload_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

                                                    <div class="row">
                                                        <%--<div class="col-lg-3">
                                                            <div class="form-group">
                                                            </div>

                                                        </div>--%>
                                                        <div class="col-lg-12">
                                                            <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnSaveGeneralInfo" Text="Save General Information" OnClick="btnSaveGeneralInfo_Click" />
                                                            <br />
                                                            <asp:Literal runat="server" ID="ltrlSaveMsg"></asp:Literal>

                                                        </div>

                                                        <div class="col-lg-3">
                                                        </div>

                                                    </div>

                                                    <asp:Panel runat="server" ID="panel1" Visible="False">
                                                        <div class="row" style="margin-top: 20px">
                                                            <div class="col-lg-12">
                                                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                                                            </div>

                                                        </div>
                                                    </asp:Panel>

                                                </div>
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto">
                                                    <h5>Contact Information
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="line-height: 1.22; margin: auto">
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: 20px; min-height: 200px; padding: 20px; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-7">

                                                            <div class="form-group">
                                                                <asp:Label ID="Label3" runat="server" CssClass="label label-info" Text="Mobile Number"></asp:Label>
                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>


                                                            </div>


                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-7">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Detail Address"></asp:Label>

                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" />

                                                            </div>

                                                        </div>

                                                    </div>
                                                    <div class="col-lg-12">
                                                        <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnSaveContact" Text="Save Contact Information" OnClick="btnSaveContact_Click" />
                                                        <br />
                                                        <asp:Literal runat="server" ID="Literal2"></asp:Literal>

                                                    </div>
                                                </div>
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto">
                                                    <h5>Payment Account Settings
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="line-height: 1.22; margin: auto">
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: 20px; min-height: 200px; padding: 20px; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-5">

                                                            <div class="form-group">
                                                            </div>


                                                        </div>
                                                        <div class="col-lg-2"></div>

                                                        <div class="col-lg-5">
                                                        </div>

                                                    </div>

                                                </div>
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto">
                                                    <h5>Update Loaging Information 
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row noPaidding" style="line-height: 1.22; margin: auto">
                                                <div class="col-lg-11 col-md-11 col-sm-12">
                                                </div>
                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: 20px; min-height: 200px; padding: 20px; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-5">

                                                            <div class="form-group">
                                                                <asp:Label ID="lblPassword" runat="server" CssClass="label label-info" Text="Password"></asp:Label>
                                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                                                <div class="rfvStyle">

                                                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="Please input Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                                                </div>

                                                            </div>


                                                        </div>
                                                        <div class="col-lg-2"></div>

                                                        <div class="col-lg-5">
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblConfirmPassword" runat="server" CssClass="label label-info" Text="Confirm Password"></asp:Label>
                                                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                                                <div class="rfvStyle">
                                                                    <asp:CompareValidator ID="cfvConfirmPassword" runat="server" ErrorMessage="Must match with Password!" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" Operator="Equal" Type="String" Display="Dynamic"></asp:CompareValidator>

                                                                </div>

                                                            </div>

                                                        </div>
                                                        <div class="col-lg-12">
                                                            <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnUpdateLoginInfo" Text="Update Login Information" />
                                                            <br />
                                                            <asp:Literal runat="server" ID="Literal3"></asp:Literal>

                                                        </div>
                                                    </div>
                                                    <div class="col-lg-11 col-md-11 col-sm-12">
                                                    </div>
                                                </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Tab1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Tab2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Tab3" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Tab4" EventName="Click" />


                        <asp:PostBackTrigger ControlID="btnupload" />

                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>
</asp:Content>
