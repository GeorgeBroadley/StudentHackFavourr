<%@ Page Title="Gift" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeDetails.aspx.cs" Inherits="WebApplication1.ChangeDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="WarnLog" runat="server" Text="You need to log in to create a favour" Visible="False" ForeColor="Red" Font-Underline="True"></asp:Label>
    <h3>Your Gift Requests</h3>
    <address>
        <br />
    </address>
    <address>
        &nbsp;
    </address>
    <address>
        Full Name:</address>
    <address>
        <asp:TextBox ID="fullName" runat="server" Height="23px" Width="252px"></asp:TextBox>
    </address>
    <address>
        Address:</address>
    <address>
        <asp:TextBox ID="address" runat="server" Height="23px" Width="252px"></asp:TextBox>
    </address>
    <address>
        Postcode</address>
    <address>
        <asp:TextBox ID="postcode" runat="server" Height="23px" Width="252px"></asp:TextBox>
    </address>
    <address>
        s<asp:Button ID="ChangeDets" runat="server" Text="Change Details" Width="303px" OnClick="ChangeDets_Click" />
    </address>
</asp:Content>