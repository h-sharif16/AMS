<%@ Page Title="" Language="C#" MasterPageFile="~/UserUI/Users.Master" AutoEventWireup="true" CodeBehind="AddApartments.aspx.cs" Inherits="AMS.UserUI.AddApartments" %>

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
                        <asp:Button Text="Apartment Detail Information" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" OnClick="Tab1_Click" />
                        <asp:Button Text="Add Apartments Picture" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                            OnClick="Tab2_Click" />
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #6495ED; color: #ffffff; border: 1px #EDF0F5 solid; min-height: 25px; margin: auto; padding-top: 10px;">
                                                    <h5>Apartment Specification
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
                                                                <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Property/House"></asp:Label>

                                                                <asp:DropDownList ID="ddlUserWiseProperty" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control"></asp:DropDownList>


                                                                <asp:RequiredFieldValidator ID="rfvPropertyType" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="ddlUserWiseProperty" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label24" runat="server" CssClass="label label-info" Text="ApartmentNo/Name"></asp:Label>


                                                                <asp:TextBox ID="txtApartmentNoOrName" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="txtApartmentNoOrName" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label1" runat="server" CssClass="label label-info" Text="Floor No"></asp:Label>

                                                                <asp:DropDownList ID="ddlFloorNo" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1st</asp:ListItem>
                                                                    <asp:ListItem Value="2">2nd</asp:ListItem>
                                                                    <asp:ListItem Value="3">3rd</asp:ListItem>
                                                                    <asp:ListItem Value="4">4th</asp:ListItem>
                                                                    <asp:ListItem Value="5">5th</asp:ListItem>
                                                                    <asp:ListItem Value="6">6th</asp:ListItem>
                                                                    <asp:ListItem Value="7">7th</asp:ListItem>
                                                                    <asp:ListItem Value="8">8th</asp:ListItem>
                                                                    <asp:ListItem Value="9">9th</asp:ListItem>
                                                                    <asp:ListItem Value="10">10th</asp:ListItem>
                                                                    <asp:ListItem Value="11">11th</asp:ListItem>
                                                                    <asp:ListItem Value="12">12th</asp:ListItem>
                                                                    <asp:ListItem Value="13">13th</asp:ListItem>
                                                                    <asp:ListItem Value="14">14th</asp:ListItem>
                                                                    <asp:ListItem Value="15">15th</asp:ListItem>
                                                                    <asp:ListItem Value="16">16th</asp:ListItem>
                                                                    <asp:ListItem Value="17">17th</asp:ListItem>
                                                                    <asp:ListItem Value="18">18th</asp:ListItem>
                                                                    <asp:ListItem Value="19">19th</asp:ListItem>
                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="refFloorNo" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="ddlFloorNo" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
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
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; min-height: 250px; margin: auto">


                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label3" runat="server" CssClass="label label-info" Text="Apartment Space"></asp:Label>
                                                                <asp:TextBox ID="txtApartmentSpace" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvApartmentSpace" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" CssClass="danger" ControlToValidate="txtApartmentSpace" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label4" runat="server" CssClass="label label-info" Text="Beds"></asp:Label>
                                                                <asp:TextBox ID="txtBeds" runat="server" CssClass="form-control"></asp:TextBox>


                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label5" runat="server" CssClass="label label-info" Text="Attached Bath"></asp:Label>

                                                                <asp:DropDownList ID="ddlAttachBatch" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                    <asp:ListItem Value="10">10</asp:ListItem>

                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label16" runat="server" CssClass="label label-info" Text="Common Bath"></asp:Label>

                                                                <asp:DropDownList ID="ddlCommonBath" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                    <asp:ListItem Value="10">10</asp:ListItem>

                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label6" runat="server" CssClass="label label-info" Text="Dining Position"></asp:Label>



                                                                <asp:DropDownList ID="ddlDiningPosition" runat="server" CssClass="form-control">

                                                                    <asp:ListItem Value="1">Space</asp:ListItem>
                                                                    <asp:ListItem Value="2">Room</asp:ListItem>
                                                                    <asp:ListItem Value="3">No Daining Space</asp:ListItem>


                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label17" runat="server" CssClass="label label-info" Text="Staff Room"></asp:Label>

                                                                <asp:DropDownList ID="ddlStaffRoom" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>

                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label18" runat="server" CssClass="label label-info" Text="Staff Toilet"></asp:Label>

                                                                <asp:DropDownList ID="ddlStaffToilet" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>


                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label19" runat="server" CssClass="label label-info" Text="Balconies"></asp:Label>

                                                                <asp:DropDownList ID="ddlBalconies" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>

                                                                </asp:DropDownList>



                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label20" runat="server" CssClass="label label-info" Text="Floor Type"></asp:Label>

                                                                <asp:DropDownList ID="ddlFloorType" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>



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
                                                    <h5>Finacial Details
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
                                                                <asp:Label ID="Label10" runat="server" CssClass="label label-info" Text="Rent"></asp:Label>

                                                                <asp:TextBox ID="txtRent" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvRent" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" CssClass="danger" ControlToValidate="txtRent" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                                        ControlToValidate="txtRent" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label7" runat="server" CssClass="label label-info" Text="Advance"></asp:Label>

                                                                <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                                        ControlToValidate="txtAdvance" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label8" runat="server" CssClass="label label-info" Text="Security"></asp:Label>

                                                                <asp:TextBox ID="txtSecurityAmount" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                                                        ControlToValidate="txtSecurityAmount" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label21" runat="server" CssClass="label label-info" Text="Service Charge"></asp:Label>

                                                                <asp:TextBox ID="txtServiceCharge" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="rfvServiceCharge"
                                                                        ControlToValidate="txtServiceCharge" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

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
                                                    <h5>Utility Cost
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
                                                                <asp:Label ID="Label9" runat="server" CssClass="label label-info" Text="Gas Bill"></asp:Label>


                                                                <asp:DropDownList ID="ddlGasBill" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">--Select Option--</asp:ListItem>
                                                                    <asp:ListItem Value="850">850</asp:ListItem>
                                                                    <asp:ListItem Value="650">650</asp:ListItem>

                                                                </asp:DropDownList>


                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label11" runat="server" CssClass="label label-info" Text="Cable Tv Bill"></asp:Label>

                                                                <asp:TextBox ID="txtCableTvBill" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                                                                        ControlToValidate="txtAdvance" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label12" runat="server" CssClass="label label-info" Text="InternetBill"></asp:Label>

                                                                <asp:TextBox ID="txtInternetBill" runat="server" CssClass="form-control"></asp:TextBox>

                                                                <div class="rfvStyle">

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                                                                        ControlToValidate="txtSecurityAmount" ValidationExpression="\d+" Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter numeric value only" ValidationGroup="saveReq" runat="server" />

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
                                                    <h5>Apartment Current Status
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
                                                                <asp:Label ID="Label13" runat="server" CssClass="label label-info" Text="Vacancy Status"></asp:Label>

                                                                <asp:DropDownList ID="ddlVacancyStatus" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" CssClass="danger" ControlToValidate="ddlVacancyStatus" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-1"></div>
                                                        <div class="col-lg-6">
                                                            <div class="form-group">
                                                                <asp:Label ID="Label15" runat="server" CssClass="label label-info" Text="Description"></asp:Label>

                                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

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
                                                    <br />
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


                                                            <div class="row noPaidding">
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label22" runat="server" CssClass="label label-info" Text="Property/House"></asp:Label>

                                                                        <asp:DropDownList ID="ddlUserWisePropertyForPicture" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlUserWisePropertyForPicture_SelectedIndexChanged"></asp:DropDownList>


                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="ddlUserWisePropertyForPicture" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="row noPaidding">
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label23" runat="server" CssClass="label label-info" Text="ApartmentNo"></asp:Label>

                                                                        <asp:DropDownList ID="ddlApartmentNo" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control"></asp:DropDownList>


                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="danger" ForeColor="Red" ControlToValidate="ddlApartmentNo" ValidationGroup="saveReq"></asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="row noPaidding">
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblPicture" runat="server" CssClass="label label-info" Text="Picture"></asp:Label>


                                                                        <asp:FileUpload ID="fudProPertyImage" runat="server" CssClass="form-control" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <asp:Label ID="Label14" runat="server" CssClass="label" Text=""></asp:Label>
                                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="form-control" OnClick="btnUpload_Click" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-6" >
                                                            <asp:GridView runat="server" ID="gdImage" HeaderStyle-BackColor="Tomato" AutoGenerateColumns="False" Width="100%">

                                                                <Columns>

                                                                    <asp:BoundField DataField="ApartmentPhotoSerial" HeaderText="ImageId" />

                                                                    <asp:BoundField DataField="PhotoName" HeaderText="ImageName" />

                                                                    <asp:TemplateField HeaderText="Image">
                                                                         
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="imgApatment" runat="server" Height="150px" Width="150px" ImageUrl='<%# Eval("PhotoUrl") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                     

                                                                </Columns>

                                                                <HeaderStyle BackColor="#6495ED" ForeColor="#ffffff" />

                                                            </asp:GridView>
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
                                                    <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnPropertyPhotoSave" Text="Save Picture" ValidationGroup="savePhoto" OnClick="btnPropertyPhotoSave_Click" />
                                                    <br />
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
