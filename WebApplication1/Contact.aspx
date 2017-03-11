<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        1 Favourr Drive<br />
        Salford, Manchester<br />
        <abbr title="Phone">Phone:</abbr>
        0161-123-4567
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@hereonline.co.uk">Support@favourr.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@hereonline.co.uk">Marketing@favourr.com</a>
    </address>
</asp:Content>