<%@ Page Title="" Language="C#" MasterPageFile="~/UserUI/Users.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AMS.UserUI.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Date: <asp:TextBox ID="TextBox1" runat="server" Height="28px" ReadOnly="True"></asp:TextBox>  
   
        <asp:ImageButton ID="ImageButton1" runat="server" Height="34px" ImageUrl="~/UserUI/img/imgCalander.png" OnClick="ImageButton1_Click" style="margin-left: 0px" Width="33px" />  
        <br />  
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px">  
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />  
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />  
            <OtherMonthDayStyle ForeColor="#CC9966" />  
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />  
            <SelectorStyle BackColor="#FFCC66" />  
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />  
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />  
        </asp:Calendar> 
</asp:Content>
