<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS.Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <div class="row noPaidding cssMainContentPlaceHolder">
        <div class="col-lg-12 col-md-12 noPaidding" style="background-color: #44AD74; min-height: 250px;">
            <div class="row">
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-user"></i> Landlord</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Receive Online Payments</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Screen Your Applicants</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Automatic Invoicing and Late Fees</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Get a Free Listing Website</span></li>
                            <li>
                                <a href="#"> More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-home"></i> Tenant</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Receive Online Payments</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Screen Your Applicants</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Automatic Invoicing and Late Fees</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Get a Free Listing Website</span></li>
                            <li>
                                <a href="#"> More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="layer">


                        <h3>
                            <a href="#"><i class="glyphicon glyphicon-inbox"></i> Service Pro</a>
                        </h3>
                        <ul>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Receive Online Payments</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Screen Your Applicants</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Automatic Invoicing and Late Fees</span></li>
                            <li>
                                <span class="glyphicon glyphicon-chevron-right"> Get a Free Listing Website</span></li>
                            <li>
                                <a href="#"> More<span class="glyphicon glyphicon-chevron-right" style="padding: 10px;"></span></a>
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
                            <img src="Images/3.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive"/>
                            <div class="carousel-caption">
                                <h3>Natural View</h3>
                                <p> Natural View with fishing pond!</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Images/4.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive"/>
                            <div class="carousel-caption">
                                <h3>Play Ground</h3>
                                <p>Several Play Ground for Mirpur Dohs Locals children.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="Images/5.jpg" alt="New York" style="height: 300px; width: 100%;" class="img-responsive"/>
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
        <div class="text-left text-capitalize" style="background-color: #F0F0F0; font-size: 20pt; padding-left: 10px; text-shadow: unset">Recent To-Let </div>
    </div>
    <div class="row noPaidding cssMainContentPlaceHolder">
        <% for (var i = 1; i <= 18; ++i)
           { %>
            <div class="col-lg-4" style="background-color: #F0F0F0; padding-bottom: 10px;">
                <div style="background-color: #ffffff; margin: 20px 10px 0px 0px; min-height: 300px;">
                    <div class="homeAdd"></div>
                </div>


            </div>
        <% } %>
        <%--  <div class="col-lg-4" style="background-color: aqua; min-height: 50px; padding: 10px"></div>
        <div class="col-lg-4" style="background-color: burlywood; min-height: 50px; padding: 10px"></div>--%>

    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdvertiseContentPlaceHolder" runat="server">

    <div class="row noPaidding">
        <div class="col-lg-12">
            <div class="newsEvent">

            </div>
        </div>

        <div class="col-lg-12">
            <div class="to-letSearchBox">

            </div>
        </div>
    </div>

</asp:Content>