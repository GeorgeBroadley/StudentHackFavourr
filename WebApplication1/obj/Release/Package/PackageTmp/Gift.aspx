<%@ Page Title="Gift" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gift.aspx.cs" Inherits="WebApplication1.Gift" %>

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
        Favour name</address>
    <address>
        <asp:TextBox ID="favourname" runat="server" Height="23px" Width="252px"></asp:TextBox>
    </address>
    <address>
        Catagory
    </address>
    <address>
        <asp:DropDownList ID="Category" runat="server" Height="30px" Width="252px">
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
        <asp:TextBox ID="Descr" runat="server" Height="316px" Width="252px"></asp:TextBox>
    </address>
    <address>
        &nbsp;
        <asp:Button ID="Create" runat="server" Text="Submit Favour" Width="303px" OnClick="Create_Click" />
    </address>
</asp:Content>