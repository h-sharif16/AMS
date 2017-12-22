<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS.Default" %>
 

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <style type="text/css">
        .addText {
            font-size: 11pt; color: #333333;font-weight: bold
        }
         .gridStyle {
             background-color: #ffffff; margin: 2px 10px 2px 20px;
             width: 100%
         }
        .adMainImage {
            margin: 10px;
            background-color: #F5F5F5;
            border: #E6E6E6 1px solid;
        }

        .adTopLowRow {

            height: 45px;
            width: 100%;
            background-color: #E6E6E6;
            position: relative;
            
        }

        .adMiddleRow {
            width: 100%;
            background-color: #FFFFFF;
        }
    </style>

    <div class="row noPaidding cssMainContentPlaceHolder">
        <div class="col-lg-12 col-md-12 noPaidding" style="background-color: #44AD74; min-height: 250px;">
            <div class="row">
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-user"></i>Landlord</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Online Rental Application</span></li>
                           
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Financial Management</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Send and Get Notification</span>

                            </li>
                             <li>
                                <span class="glyphicon glyphicon-chevron-right">On-demand Reports</span>

                            </li>
                             <li>
                                <span class="glyphicon glyphicon-chevron-right">Tenant Match</span>

                            </li>
                            <li>
                                <a href="#">More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-home"></i>Tenant</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Online Rental Application</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Perfect Home Search</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Online/Digital Payments</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Maintenance Requests & Notification</span></li>
                            <li>
                                <a href="#">More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-inbox"></i>Service Pro</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Ads on vacancy</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">NID Verification </span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Agreement/Contract Management</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Financial management</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right">Smart notification</span></li>
                            <li>
                                <a href="#">More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="row noPaidding cssMainContentPlaceHolder">
        <div class="col-lg-12 col-md-12 noPaidding" style="background-color: #8F8F8F; min-height: 300px;">

            <div style="min-height: 300px; padding: 5px; width: 100%;">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                        <li data-target="#myCarousel" data-slide-to="4"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="Images/1.jpg" alt="Chania" style="height: 300px; width: 100%;" class="img-responsive">
                            <div class="carousel-caption">
                                <h3>Mirpur Dohs</h3>
                                <p>Mirpur Dohs view!</p>
                            </div>
                        </div>

                        <div class="item">
                            <img src="Images/2.jpg" alt="Chicago" style="height: 300px; width: 100%;" class="img-responsive">
                            <div class="carousel-caption">
                                <h3>Mirpur Dohs</h3>
                                <p>Mirpur Dohs Night view!</p>
                            </div>
                        </div>

                        <div class="item">
                            <img src="Images/3.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive" />
                            <div class="carousel-caption">
                                <h3>Natural View</h3>
                                <p>Natural View with fishing pond!</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Images/4.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive" />
                            <div class="carousel-caption">
                                <h3>Play Ground</h3>
                                <p>Several Play Ground for Mirpur Dohs Locals children.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Images/5.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive" />
                            <div class="carousel-caption">
                                <h3>Children Park</h3>
                                <p>Children Park for Kids!</p>
                            </div>
                        </div>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>


            </div>
        </div>
    </div>

    <div class="row noPaidding cssMainContentPlaceHolder">
        <div class="text-left text-capitalize" style="background-color: #F0F0F0; font-size: 20pt; padding-left: 10px;  ">Recent To-Let </div>
    </div>
    <div class="row  cssMainContentPlaceHolder">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridStyle" BorderStyle="None" ShowHeader="False"  OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BorderStyle="None" />
            <Columns>
                <asp:TemplateField>
                     
                    <ItemTemplate>
                        <div class="adMainImage">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoUrl") %>' />
                            </div>
                    </ItemTemplate>
                    <ControlStyle  Height="100px" Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    
                    <ItemTemplate>
                        <div class="row adTopLowRow noPaidding">
                        <div class="col-lg-6 addText"><asp:Label ID="lblId" runat="server">ID: <%#Eval("ApartmentId") %></asp:Label></div>  
                              <div class="col-lg-6 addText" style="text-align: right"><asp:Label ID="Label8" runat="server"> <%#Eval("PropertyTypeName") %></asp:Label></div> 
                            </div>
                        <div class="row adMiddleRow noPaidding">
                        <div class="col-lg-6 addText"><asp:Label ID="Label9" runat="server">Rent: <%#Eval("Rent") %></asp:Label></div>  
                              <div class="col-lg-6"  style="text-align: right; margin-top: 5px;margin-bottom: 5px">
                                  <asp:HyperLink ID="idAddDetail" CssClass="btn btn-primary" NavigateUrl='<%# string.Format("AddDetail.aspx?lId={0}&apId={1}&ppId={2}",
                    HttpUtility.UrlEncode(Eval("LandloadId").ToString()), HttpUtility.UrlEncode(Eval("ApartmentId").ToString()), HttpUtility.UrlEncode(Eval("PropertyId").ToString())) %>'  runat="server">More Details </asp:HyperLink>
                                  </div> 
                            </div>
                         <div class="row adTopLowRow noPaidding">
                        <div class="col-lg-3 icon-page addText"><asp:Label ID="Label10" runat="server"> <%#Eval("ApartmentSpace") %> sft</asp:Label></div>
                               <div class="col-lg-3 icon-grid addText"><asp:Label ID="Label12" runat="server"> <%#Eval("Beds") %> Beadrooms</asp:Label></div>  
                             <div class="col-lg-3 icon-interface-windows addText"><asp:Label ID="Label13" runat="server"> <%#Eval("AttachBatch") %> Bathrooms</asp:Label></div>  
                              <div class="col-lg-3 addText " style="text-align: right"><asp:Label ID="Label11" runat="server"> Parking: <%# Eval("IsParkingAvailable") %></asp:Label></div> 
                            </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <EditRowStyle BorderStyle="None" />
            
        </asp:GridView>
      
        
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdvertiseContentPlaceHolder" runat="server">

    <div class="row noPaidding">
        <div class="col-lg-12">
            <div class="newsEvent">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <br />
                        <marquee direction="up" scrollamount="3">
                              <asp:Label ID="lblWelcome" runat="server" CssClass="label" Text="Welcome to Pentasoft Project" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="#003300"></asp:Label><br /><br/>
                        <asp:Label ID="lblTeam" runat="server" CssClass="label" Text="Project Team" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="#993300"></asp:Label>

                        <ul>
                            <li style="color:#D46900; font-size: 12pt;">AMS Projet Team 
                                <ul style="color: #0000cd;font-style: italic">
                                    <li>Md. Hasan Sharif (1601014)
                                    </li>
                                    <li>
                                        A N M Wasiul Anwar (1601026)
                                    </li>
                                      <li>Mohammad Zillur Rahaman (1601038)
                                    </li>
                                    <li>
                                       Md Sirajus Salehin Shuvo (1601021)
                                    </li>
                                </ul>

                            </li>
                            <li style="color: #D46900; font-size: 12pt;">Supervisor
                                <ul style="color: #0000cd;font-style: italic">
                                    <li>Dr Md Zahurul Islam Sarkar
                                    </li>
                                     
                                    
                                </ul>

                            </li>
                        </ul>
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Event" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="#993300"></asp:Label><br />

                        <ul  >
                            <li style="color: #D46900; font-size: 12pt;">AMS Projet Presentation 
                                <ul style="color: #0000cd;font-style: italic">
                                     <li>Date: 20th December 2017
                                    </li>
                                    <li>Time: 10 am
                                    </li>
                                    <li>Venu: Bangladesh University Of Professionals (BUP)
                                    </li>
                                </ul>

                            </li>
                            <li style="color: #D46900; font-size: 12pt;">AMS Launching ceremony
                                <ul style="color: #0000cd;font-style: italic">
                                    <li>Date: 20th December 2017
                                    </li>
                                    <li>Venu: Bangladesh University Of Professionals (BUP)
                                    </li>
                                    <li>
                                        Chief Guest: Brig Gen Shaikh Muhammad Rizwan Ali, psc, te 
                                       </li>
                                </ul>

                            </li>
                        </ul></marquee>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12">
            <div class="to-letSearchBox">
                <br />
                <asp:UpdatePanel runat="server" ID="updatePanelTab">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" CssClass="label label-info" Text="Country"></asp:Label>

                                    <asp:DropDownList ID="ddlCountry" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>



                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" CssClass="label label-info" Text="Sate/Division"></asp:Label>

                                    <asp:DropDownList ID="ddlDivision" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDivision" ValidationGroup="saveReq"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" CssClass="label label-info" Text="City"></asp:Label>

                                    <asp:DropDownList ID="ddlCity" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>



                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" CssClass="label label-info" Text="Thana/Area"></asp:Label>

                                    <asp:DropDownList ID="dllThanaOrArea" DataTextField="DataText" DataValueField="DataValue" runat="server" CssClass="form-control"></asp:DropDownList>



                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" CssClass="label label-info" Text="Price From"></asp:Label>

                                            <asp:TextBox ID="txtPiceFrom" runat="server" Style="width: 100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" CssClass="label label-info" Text="Price To"></asp:Label>

                                            <asp:TextBox ID="txtPrceTo" runat="server" Style="width: 100%"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <asp:Button ID="btnSearch" CssClass="col-lg-12 btn btn-success" runat="server" Text="Search Now" Style="left: 0px; top: 0px" />

                                </div>

                            </div>
                        </div>
                        <br />
                    </ContentTemplate>
                    <Triggers></Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
