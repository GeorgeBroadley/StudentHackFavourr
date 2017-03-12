<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="WebApplication1.Welcome" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Label ID="WelcomeText" runat="server" Text="Welcome!"></asp:Label>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    
</asp:Content>
