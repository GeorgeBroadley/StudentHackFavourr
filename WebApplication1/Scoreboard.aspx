<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scoreboard.aspx.cs" Inherits="WebApplication1.Scoreboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Welcome to Favourr</h1>
        <p class="lead">Welcome to FAVOURR where good favourr gain more good favourrs</p>
     </div>
    <div class="row">
        <asp:Panel ID="usersTable" runat="server"></asp:Panel>
    </div>
</asp:Content>
