<%@ Page Title="" Language="C#" MasterPageFile="~/UserUI/Users.Master" AutoEventWireup="true" CodeBehind="ResponseVisitRequest.aspx.cs" Inherits="AMS.UserUI.ResponseVisitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row noPaidding" style="margin: auto">

        <!-- Div for signup form-->
        <div class="col-lg-11 col-md-11 col-sm-12 pageHeading">
            <h5>Visit Request Detail
            </h5>
        </div>
    </div>
    <div class="row noPaidding" style="margin: auto">

        <!-- Div for signup form-->
        <div class="col-lg-11 col-md-11 col-sm-12 pageContentBg">
            <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label1" CssClass="label label-default" runat="server" Text="Reqursted By"></asp:Label>
                  

                </div>
                <div class="col-lg-1">:</div>
                 <div class="col-lg-5 text text-gray-dark " >
                      
                         <asp:Label  CssClass="label label-default"  ID="lblRequrstedBy" runat="server" ></asp:Label>
                    

                </div>
            </div>
            <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label2" CssClass="label label-default" runat="server" Text="Client Mobile No"></asp:Label>
                  

                </div>
                <div class="col-lg-1">:</div>
                <div class="col-lg-5 text text-gray-dark " >
                    <asp:Label ID="lblClientMobileNo" runat="server" ></asp:Label>
                    

                </div>
            </div>
            <div class="row rowTopMergin" >
                <div class="col-lg-1"></div>
                 <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label3" CssClass="label label-default" runat="server" Text="Client  Email"></asp:Label>
                  

                </div>
                <div class="col-lg-1">:</div>
                <div class="col-lg-5 text text-gray-dark " >
                   <asp:Label ID="lblClientEmail" runat="server"  ></asp:Label>
                    

                </div>
            </div>
            <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label5" CssClass="label label-default" runat="server" Text="Reqursted for"></asp:Label>
                  

                </div>
                <div class="col-lg-1">:</div>
                 <div class="col-lg-5 text text-gray-dark " >
                      
                         <asp:Label  CssClass="label label-default"  ID="lblRequestedFor" runat="server" ></asp:Label>
                    

                </div>
            </div>
              <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                   <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label4" CssClass="label label-default" runat="server" Text="Message From Client"></asp:Label>
                  

                </div>
                    <div class="col-lg-1">:</div>
                <div class="col-lg-5 text text-gray-dark" >
                  
                  <asp:TextBox ID="txtClientMessage" CssClass="form-control" ReadOnly="True"  runat="server" TextMode="MultiLine" ></asp:TextBox>
 
                </div>
            </div>
            
                        <asp:UpdatePanel runat="server" ID="updatePanelTab">
                    <ContentTemplate>
                         <asp:Panel runat="server" ID="pnlMessage" Visible="False">
                
                <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                   <div class="col-lg-3 text text-gray-dark " >
                     
                         <asp:Label ID="Label6" CssClass="label label-default" runat="server" Text="Message To Client"></asp:Label>
                  

                </div>
                    <div class="col-lg-1">:</div>
                <div class="col-lg-5 text text-gray-dark" >
                  
                  <asp:TextBox ID="txtMessageToClient" CssClass="form-control"  runat="server" TextMode="MultiLine" ></asp:TextBox>
 
                </div>
            </div>
            </asp:Panel>
                <div class="row rowTopMergin">
                <div class="col-lg-1"></div>
                   <div class="col-lg-8 text text-gray-dark " >
                       
                            
                          <asp:CheckBox ID="chkToViewMessageBox" runat="server" CssClass="checkbox-inline form-group" Text="&nbsp; To Send a Customize message click Here.."  TextAlign="Right" style="color: #404753; font-family: sans-serif; font-size: 10pt; font-weight: normal;" AutoPostBack="True" OnCheckedChanged="chkToViewMessageBox_CheckedChanged" ViewStateMode="Enabled"/> 

                       
                  

                </div>
                
            </div>

           
                        </ContentTemplate>
                            </asp:UpdatePanel>
              <asp:Panel runat="server" ID="pnlAcceptReq" Visible="True">
                <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; color: #ffffff;  margin: auto; padding-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success" Style="width: 100%" ID="btnAccept" Text="Accept & Send Message To Client" OnClick="btnAccept_Click" />
                                                    <br />
                                                    <asp:Literal runat="server" ID="ltrlEmailSmsNotificationA"></asp:Literal>
                                                </div>
                                            </div>

            </asp:Panel>
            <asp:Panel runat="server" ID="pnlDenyReq" Visible="True">
                <div class="row noPaidding" style="margin: auto">

                                                <!-- Div for signup form-->
                                                <div class="col-lg-11 col-md-11 col-sm-12" style="background-color: #ffffff; color: #ffffff;  margin: auto; padding-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-danger" Style="width: 100%" ID="btnDeny" Text="Deny Request"  UseSubmitBehavior="False" OnClick="btnDeny_Click" />
                                                    <br />
                                                    <asp:Literal runat="server" ID="ltrlEmailSmsNotificationD"></asp:Literal>
                                                </div>
                                            </div>

            </asp:Panel>

        </div>
    </div>
</asp:Content>
