<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Welcome to Favourr</h1>
        <p class="lead">Welcome to FAVOURR where good favourr gain more good favourrs</p>
        <p>

            <asp:ImageButton ID="ImageButton1" ImageUrl="Content/coins-1015125_640.jpg" runat="server" Height="140px" Width="200px" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="ImageButton2" ImageUrl="Content/ipad-606766_640.jpg" runat="server" Height="140px" Width="200px" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="ImageButton3" ImageUrl="Content/lawnmower-384589_640.jpg" runat="server" Height="140px" Width="200px" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="ImageButton4" ImageUrl="Content/old-paint-brush-1061955_640.jpg" runat="server" Height="140px" Width="200px" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="ImageButton5" ImageUrl="Content/mercedes-benz-1461507_640.jpg" runat="server" Height="140px" Width="200px" />
            <!--OnClick="ImageButton_Click"-->
    </div>

    <div class="row">
    </div>
</asp:Content>
