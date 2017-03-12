<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gift.aspx.cs" Inherits="WebApplication1.Gift" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Your Gift Requests</h3>
    <address>
        <br />
    </address>
    <address>
        &nbsp;
    </address>
    <address>
        Email
    </address>
    <address>
        <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="252px"></asp:TextBox>
    </address>
    <address>
        Catagory
    </address>
    <address>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="252px">
            <asp:ListItem>Accounting</asp:ListItem>
            <asp:ListItem>Technical Help</asp:ListItem>
            <asp:ListItem>Gardening</asp:ListItem>
            <asp:ListItem>Decorating</asp:ListItem>
            <asp:ListItem>Mechanical</asp:ListItem>
        </asp:DropDownList>
    </address>
    <address>
        Description
    </address>
    <address>
        <asp:TextBox ID="TextBox3" runat="server" Height="316px" Width="252px"></asp:TextBox>
    </address>
    <address>
        &nbsp;
    </address>
</asp:Content>