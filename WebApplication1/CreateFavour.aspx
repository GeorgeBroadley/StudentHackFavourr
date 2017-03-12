<%@ Page Title="Create Favour" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gift.aspx.cs" Inherits="WebApplication1.Gift" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="WarnLog" runat="server" Text="You need to log in to create a favour" Visible="False" ForeColor="Red" Font-Underline="True"></asp:Label>
    <h3>Your Favour Requests</h3>
    <br />
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="favourname" CssClass="col-md-2 control-label">Favour name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="favourname" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Category" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Category" CssClass="form-control" runat="server">
                    <asp:ListItem>Accounting</asp:ListItem>
                    <asp:ListItem>Technical Help</asp:ListItem>
                    <asp:ListItem>Gardening</asp:ListItem>
                    <asp:ListItem>Decorating</asp:ListItem>
                    <asp:ListItem>Mechanical</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Descr" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Descr" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>    
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Create" runat="server" OnClick="Create_Click" Text="Submit Favour" CssClass="btn btn-default" Height="44px" Width="140px" />
            </div>
        </div>
    </div>
</asp:Content>