<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendVisitRequest.aspx.cs" Inherits="AMS.SendVisitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
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
    <div class="row">
        <div class="col-lg-2 col-sm-2"></div>
        <div class="col-lg-8 col-sm-8">
            <div class="row">
                <div class="col-lg-10">
                    
                    <div class="form-group" style="margin-bottom: 0px">
                        <asp:Label ID="lblClientName" runat="server" CssClass="label label-info" Text="Your Name"></asp:Label>
                        <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control validate[required]"  />&nbsp;
                            
                    </div>
                    <div class="col-lg-2 rfvErrorMsg">
                        <asp:RequiredFieldValidator ID="rfvClientName" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="red" ControlToValidate="txtClientName" SetFocusOnError="False"></asp:RequiredFieldValidator>
                    </div>
                </div>


            </div>

            <div class="row">
                <div class="col-lg-10">
                    <div class="form-group" style="margin-bottom: 0px">
                        <asp:Label ID="lblClientEmail" runat="server" CssClass="label label-info" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtClientEmail" runat="server" CssClass="form-control" AutoPostBack="False" />
                        <div class="rfvStyle">

                            <asp:RegularExpressionValidator ID="refvEmail" runat="server" Display="Dynamic" ErrorMessage="Invalid Email" ControlToValidate="txtClientEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        
                    </div>
                    <div class="col-lg-2 rfvErrorMsg">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="red" ControlToValidate="txtClientEmail"></asp:RequiredFieldValidator>
                    </div>
                </div>


            </div>

            <div class="row" style="margin-top: 10px">
                <div class="col-lg-10">
                    <div class="form-group" style="margin-bottom: 0px">
                        <asp:Label ID="lblClientMobileNo" runat="server" CssClass="label label-info" Text="Mobile No"></asp:Label>
                        <asp:TextBox ID="txtClientMobileNo" runat="server" CssClass="form-control" AutoPostBack="False" />
                        <div class="rfvStyle">

                            <asp:RegularExpressionValidator ID="refvMobileNo" runat="server"
                                ControlToValidate="txtClientMobileNo" ErrorMessage="Mobile Number is not valid." ValidationExpression="[0-9]{11}" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </div>

                    </div>
                    <div class="col-lg-2 rfvErrorMsg">
                         
                    </div>
                </div>


            </div>
            
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-10">
                    <div class="form-group" style="margin-bottom: 0px">
                        <asp:Label ID="Label1" runat="server" CssClass="label label-info" Text="Message to Landlord"></asp:Label>
                        <asp:TextBox ID="txtVisitReqMessage" runat="server" CssClass="form-control"  TextMode="MultiLine" />
                        

                    </div>
                    <div class="col-lg-2 rfvErrorMsg">
                          <asp:RequiredFieldValidator ID="rfvVisitReqMessage" runat="server" Display="Dynamic" SetFocusOnError="True" ErrorMessage="*" ForeColor="red" ControlToValidate="txtClientEmail"></asp:RequiredFieldValidator>
                    </div>
                </div>


            </div>
            <div class="row">
                <div class="col-lg-10" style="margin-top: 10px">
                    <div class="form-group">
                        <asp:Button ID="btnSendVisitReq" CssClass="col-lg-12 btn btn-success" runat="server" Text="Send Visit Request" OnClick="btnSendVisitReq_Click" />
                        <br/>
                        <asp:Literal ID="ltrlEmailSmsNotification" runat="server"></asp:Literal>

                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-2 col-sm-2"></div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdvertiseContentPlaceHolder" runat="server">
</asp:Content>
