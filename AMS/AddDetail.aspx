<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDetail.aspx.cs" Inherits="AMS.AddDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <style type="text/css">
        .lblId{background-color: #E6E6E6; width: 100%}
        
        .lblName{ font-size: 11pt; color: #333333;font-weight: bold}
        .hylSendVisitReq {
            font-size: 11pt;
            color: #ffffff;
            text-decoration: none;
            padding: 5px;
        }
        .hylSendVisitReq a:link {
            color: #ffffff;
          
        }
        .hylSendVisitReq a:hover {
            color: Red;
            
        }
        .hylSendVisitReq a:visited {
            color: #696969;
            
        }
    </style>
     <div class="row">
         <div class="col-lg-2"></div>
        <div class="col-lg-9"  >
            <div class="row">
                <div class="col-lg-10">
                    <div class="row"  >
                        <div class="col-lg-8">
                            Property ID:<asp:Label runat="server" ID="lblPropertyId"></asp:Label><br/>
                        </div>
                        </div>
                     <div class="row">
                        <div class="col-lg-7">
                    <asp:GridView ID="gvApartmentWiseImg" CssClass="lblId" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                        <Columns>
                            <asp:ImageField DataImageUrlField="PhotoUrl">
                            </asp:ImageField>
                        </Columns>
                        
                    </asp:GridView>
                            </div>
                         
                         <div class="col-lg-5" style="">
                             <div class="row" style="background-color: #D8D6D1">
                                 <div class="col-lg-11">Property Detail</div>
                             </div>
                             <div class="row" style="background-color: #F8F8F8;border-bottom: #D8D6D1 1px solid ">
                                 <div class="col-lg-11">
                                    Space: <asp:Label ID="lblApSpace" runat="server" ></asp:Label></div>sft
                             </div>
                             <div class="row" style="background-color: #F8F8F8;border-bottom: #D8D6D1 1px solid ">
                                 <div class="col-lg-11">
                                     Bed: <asp:Label ID="lblBed" runat="server" ></asp:Label></div>
                             </div>
                                <div class="row" style="background-color: #F8F8F8;border-bottom: #D8D6D1 1px solid ">
                                 <div class="col-lg-11">
                                    Bath:   <asp:Label ID="lblBath" runat="server" ></asp:Label></div>
                             </div>
                              <div class="row" style="background-color: #F8F8F8;border-bottom: #D8D6D1 1px solid ">
                                 <div class="col-lg-11">
                                    FloorType:  <asp:Label ID="lblFloorType" runat="server" ></asp:Label></div>
                             </div>
                             <div class="row" style="background-color: #F8F8F8;border-bottom: #D8D6D1 1px solid ">
                                 <div class="col-lg-11">
                                    Rent: <asp:Label ID="lblRent" runat="server" ></asp:Label></div>
                             </div>
                         </div>
                        </div><br/>

                </div>
            </div>
        </div>
         
         
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdvertiseContentPlaceHolder" runat="server">
    <div class="row" style="width: 100%;margin-top: 10px">
      <div class="col-lg-2"></div>
        <div class="col-lg-10">
            <div class="row"  style="color: #ffffff; background-color: #006400; font-size: 11pt;min-height: 45px">
                <div class="col-lg-10">
                    Advertiser
                </div>
            </div>
             <div class="row"  style="color: #ffffff; background-color:  #EFEFEF;font-size: 11pt;min-height: 45px">
                <div class="col-lg-10">
                   <span class="lblName">    <span class="glyphicon glyphicon-user"></span> <asp:Label ID="lblLanloard" runat="server" CssClass="lblName" ></asp:Label></span><br/>

                 <span class="lblName">   <span class="glyphicon glyphicon-phone"></span>   <asp:Label ID="lblLanloardMobile" runat="server" ></asp:Label></span>
                </div>
            </div>
              <div class="row" style="color: #ffffff; background-color: #006400; font-size: 11pt;;min-height: 45px">
                <div class="col-lg-10" >
                  <span class="glyphicon glyphicon-hand-right"></span> <asp:HyperLink ID="hylSendVisitReq"    runat="server" CssClass="hylSendVisitReq" BorderStyle="None"> Send a Visit Request</asp:HyperLink> 
                </div>
            </div>
        </div>
       </div>
</asp:Content>
