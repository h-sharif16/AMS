<%@ Page Title="" Language="C#" MasterPageFile="~/UserUI/Users.Master" AutoEventWireup="true" CodeBehind="AddProperty.aspx.cs" Inherits="AMS.UserUI.AddProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            width: 49.4%;
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
            width: 49.4%;
        }
    </style>
    <div class="container" style="margin: auto">

        <div class="row noPaidding">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="updatePanelTab">
                    <ContentTemplate>
                        <asp:Button Text="Property Detail Information" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" OnClick="Tab1_Click" />
                        <asp:Button Text="Add Picture" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                            OnClick="Tab2_Click" />
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Property Title
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Property Type"></asp:Label>

                                                                <asp:DropDownList ID="ddlPropertyType" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="rfvPropertyType" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="ddlPropertyType" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label1" runat="server" CssClass="label label-info" Text="Property Name"></asp:Label>

                                                                <asp:TextBox ID="txtPropertyName" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>




                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Property Address
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; min-height: 250px; margin: auto">


                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label3" runat="server" CssClass="label label-info" Text="Property Built Year"></asp:Label>
                                                                <asp:TextBox ID="txtBuiltYear" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" CssClass="danger" ControlToValidate="txtBuiltYear" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label4" runat="server" CssClass="label label-info" Text="Country"></asp:Label>

                                                                <asp:DropDownList ID="ddlCountry" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCountry" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label5" runat="server" CssClass="label label-info" Text="Sate/Division"></asp:Label>

                                                                <asp:DropDownList ID="ddlDivision" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDivision" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label6" runat="server" CssClass="label label-info" Text="City"></asp:Label>

                                                                <asp:DropDownList ID="ddlCity" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCity" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label7" runat="server" CssClass="label label-info" Text="Thana/Area"></asp:Label>

                                                                <asp:DropDownList ID="dllThanaOrArea" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="rfvThanaOrArea" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="dllThanaOrArea" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label8" runat="server" CssClass="label label-info" Text="Holding/House No"></asp:Label>

                                                                <asp:TextBox ID="txtHoldingOrHouseNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvHoldingOrHouseNo" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoldingOrHouseNo" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label15" runat="server" CssClass="label label-info" Text="Road No"></asp:Label>

                                                                <asp:TextBox ID="txtRoadNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvRoadNo" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRoadNo" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label9" runat="server" CssClass="label label-info" Text="Sector"></asp:Label>

                                                                <asp:TextBox ID="txtSector" runat="server" CssClass="form-control"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>




                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Property Speccification
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label10" runat="server" CssClass="label label-info" Text="Property Total Space"></asp:Label>

                                                                <asp:TextBox ID="txtTotalSpace" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                                        ControlToValidate="txtTotalSpace" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label11" runat="server" CssClass="label label-info" Text="No Of Floors"></asp:Label>

                                                                <asp:TextBox ID="txtNoOfFloors" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="rgeNoOfFloors"
                                                                        ControlToValidate="txtNoOfFloors" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server" ValidationGroup="saveReq" />
                                                                   <%-- <asp:RangeValidator ID="rngvNoOfFloors" runat="server" ErrorMessage="enter only numbers between 1 and 36" MaximumValue="36" MinimumValue="1" Display="Dynamic" ControlToValidate="txtNoOfFloors" ValidationGroup="saveReq"></asp:RangeValidator>--%>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label12" runat="server" CssClass="label label-info" Text="Is Parking Availabel?"></asp:Label>

                                                                <asp:RadioButtonList ID="rblIsParkingAvailabel" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CellSpacing="10" CssClass="radio-inline" OnSelectedIndexChanged="rblIsParkingAvailabel_SelectedIndexChanged" CellPadding="10" style="width: 143px">
                                                                    <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                    <asp:ListItem Value="True">Yes</asp:ListItem>

                                                                </asp:RadioButtonList>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <asp:Panel runat="server" ID="pnlIsParkingAvailable" Visible="False">
                                                        <div class="row">
                                                            <div class="col-lg-1"></div>
                                                            <div class="col-lg-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label13" runat="server" CssClass="label label-info" Text="Parking Total Space"></asp:Label>

                                                                    <asp:TextBox ID="txtParkingTotalSpace" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    <div class="rfvStyle">

                                                                        <asp:RegularExpressionValidator ID="revParkingTotalSpace"
                                                                            ControlToValidate="txtParkingTotalSpace" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" runat="server" ValidationGroup="saveReq" />

                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </div>

                                                    </asp:Panel>
                                                </div>
                                            </div>




                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Facilities
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-7">
                                                            <div class="form-group">
                                                                <asp:CheckBoxList ID="ckblPropertyFacilities" runat="server" CellSpacing="20" DataTextField="DataText" DataValueField="DataValue" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="checkbox-inline" CellPadding="10" Width="100%">
                                                                </asp:CheckBoxList>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Security
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-7">
                                                            <div class="form-group">
                                                                <asp:CheckBoxList ID="ckblPropertySecurity" runat="server" CellSpacing="20" DataTextField="DataText" DataValueField="DataValue" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="checkbox-inline" CellPadding="10" Width="100%">
                                                                </asp:CheckBoxList>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                            </div>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; color: #ffffff; border: 1px #EDF0F5 solid; margin: auto; padding-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnPropertyInfoSave" Text="Save" OnClick="btnPropertyInfoSave_Click" ValidationGroup="saveReq" />
                                                    <br/>
                                                            <asp:Literal runat="server" ID="ltrlSaveMsg"></asp:Literal>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Picture
                                                    </h5>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; margin: auto">
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-5">
                                                         <div class="form-group">
                                                                <div class="row noPaidding">
                                                                <div class="col-lg-6">
                                                                <asp:Label ID="lblPicture" runat="server" CssClass="label label-info" Text="Picture"></asp:Label>


                                                                <asp:FileUpload ID="fudProPertyImage" runat="server" CssClass="form-control" />
                                                                </div>
                                                                <div class="col-lg-6" >
                                                                     <asp:Label ID="Label14" runat="server" CssClass="label" Text=""></asp:Label>
                                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="form-control" OnClick="btnUpload_Click"/>
                                                                </div>
                                                                    </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6" style="border: #464a4c 1px solid">
                                                            <asp:Image runat="server" ID="imgPropertyPhotoTemp" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; color: #ffffff; border: 1px #EDF0F5 solid; margin: auto; padding-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnPropertyPhotoSave" Text="Save Picture"  ValidationGroup="savePhoto" />
                                                     <br/>
                                                            <asp:Literal runat="server" ID="ltrlPhotoSaveMsg"></asp:Literal>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpload" />

                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>

    </div>
</asp:Content>
