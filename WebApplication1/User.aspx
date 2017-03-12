<%@ Page Title="User Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication1.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="userFavours" runat="server" Height="237px" style="margin-bottom: 0px">
        <asp:Button ID="ChangeDetails" runat="server" Text="Button" Height="29px" OnClick="ChangeDetails_Click" Width="136px" />
    </asp:Panel>
    
</asp:Content>