<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <asp:Label ID="EmailWarn" runat="server" Text="That email is already in use" Visible="False" ForeColor="Red" Font-Underline="True"></asp:Label>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Address" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                    CssClass="text-danger" ErrorMessage="An address is required." />
            </div>
        </div>
        
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="County" CssClass="col-md-2 control-label">County</asp:Label>
            <div class="col-md-10">
                <!--<asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Postcode"
                    CssClass="text-danger" ErrorMessage="A post code is required." />-->
                <asp:DropDownList ID="County" runat="server" CssClass="form-control">
                    <asp:ListItem>Bedfordshire</asp:ListItem>
                    <asp:ListItem>Berkshire</asp:ListItem>
                    <asp:ListItem>Bristol</asp:ListItem>
                    <asp:ListItem>Buckinghamshire</asp:ListItem>
                    <asp:ListItem>Cambridgeshire</asp:ListItem>
                    <asp:ListItem>Cheshire</asp:ListItem>
                    <asp:ListItem>City of London</asp:ListItem>
                    <asp:ListItem>Cornwall</asp:ListItem>
                    <asp:ListItem>Cumbria</asp:ListItem>
                    <asp:ListItem>Derbyshire</asp:ListItem>
                    <asp:ListItem>Devon</asp:ListItem>
                    <asp:ListItem>Dorset</asp:ListItem>
                    <asp:ListItem>Durham</asp:ListItem>
                    <asp:ListItem>East Riding of Yorkshire</asp:ListItem>
                    <asp:ListItem>East Sussex</asp:ListItem>
                    <asp:ListItem>Essex</asp:ListItem>
                    <asp:ListItem>Gloucestershire</asp:ListItem>
                    <asp:ListItem>Greater London</asp:ListItem>
                    <asp:ListItem>Greater Manchester</asp:ListItem>
                    <asp:ListItem>Hampshire</asp:ListItem>
                    <asp:ListItem>Herefordshire</asp:ListItem>
                    <asp:ListItem>Hertfordshire</asp:ListItem>
                    <asp:ListItem>Isle of Wight</asp:ListItem>
                    <asp:ListItem>Kent</asp:ListItem>
                    <asp:ListItem>Lancashire</asp:ListItem>
                    <asp:ListItem>Leicestershire</asp:ListItem>
                    <asp:ListItem>Lincolnshire</asp:ListItem>
                    <asp:ListItem>Merseyside</asp:ListItem>
                    <asp:ListItem>Norfolk</asp:ListItem>
                    <asp:ListItem>North Yorkshire</asp:ListItem>
                    <asp:ListItem>Northamptonshire</asp:ListItem>
                    <asp:ListItem>Northumberland</asp:ListItem>
                    <asp:ListItem>Nottinghamshire</asp:ListItem>
                    <asp:ListItem>Oxfordshire</asp:ListItem>
                    <asp:ListItem>Rutland</asp:ListItem>
                    <asp:ListItem>Shropshire</asp:ListItem>
                    <asp:ListItem>Somerset</asp:ListItem>
                    <asp:ListItem>South Yorkshire</asp:ListItem>
                    <asp:ListItem>Staffordshire</asp:ListItem>
                    <asp:ListItem>Suffolk</asp:ListItem>
                    <asp:ListItem>Surrey</asp:ListItem>
                    <asp:ListItem>Tyne and Wear</asp:ListItem>
                    <asp:ListItem>Warwickshire</asp:ListItem>
                    <asp:ListItem>West Midlands</asp:ListItem>
                    <asp:ListItem>West Sussex</asp:ListItem>
                    <asp:ListItem>West Yorkshire</asp:ListItem>
                    <asp:ListItem>Wiltshire</asp:ListItem>
                    <asp:ListItem>Worcestershire</asp:ListItem>
                    <asp:ListItem>Anglesey</asp:ListItem>
                    <asp:ListItem>Brecknockshire</asp:ListItem>
                    <asp:ListItem>Caernarfonshire</asp:ListItem>
                    <asp:ListItem>Carmarthenshire</asp:ListItem>
                    <asp:ListItem>Cardiganshire</asp:ListItem>
                    <asp:ListItem>Denbighshire</asp:ListItem>
                    <asp:ListItem>Flintshire</asp:ListItem>
                    <asp:ListItem>Glamorgan</asp:ListItem>
                    <asp:ListItem>Merioneth</asp:ListItem>
                    <asp:ListItem>Monmouthshire</asp:ListItem>
                    <asp:ListItem>Montgomeryshire</asp:ListItem>
                    <asp:ListItem>Pembrokeshire</asp:ListItem>
                    <asp:ListItem>Radnorshire</asp:ListItem>
                    <asp:ListItem>Aberdeenshire</asp:ListItem>
                    <asp:ListItem>Angus</asp:ListItem>
                    <asp:ListItem>Argyllshire</asp:ListItem>
                    <asp:ListItem>Ayrshire</asp:ListItem>
                    <asp:ListItem>Banffshire</asp:ListItem>
                    <asp:ListItem>Berwickshire</asp:ListItem>
                    <asp:ListItem>Buteshire</asp:ListItem>
                    <asp:ListItem>Cromartyshire</asp:ListItem>
                    <asp:ListItem>Caithness</asp:ListItem>
                    <asp:ListItem>Clackmannanshire</asp:ListItem>
                    <asp:ListItem>Dumfriesshire</asp:ListItem>
                    <asp:ListItem>Dunbartonshire</asp:ListItem>
                    <asp:ListItem>East Lothian</asp:ListItem>
                    <asp:ListItem>Fife</asp:ListItem>
                    <asp:ListItem>Inverness-shire</asp:ListItem>
                    <asp:ListItem>Kincardineshire</asp:ListItem>
                    <asp:ListItem>Kinross</asp:ListItem>
                    <asp:ListItem>Kirkcudbrightshire</asp:ListItem>
                    <asp:ListItem>Lanarkshire</asp:ListItem>
                    <asp:ListItem>Midlothian</asp:ListItem>
                    <asp:ListItem>Morayshire</asp:ListItem>
                    <asp:ListItem>Nairnshire</asp:ListItem>
                    <asp:ListItem>Orkney</asp:ListItem>
                    <asp:ListItem>Peeblesshire</asp:ListItem>
                    <asp:ListItem>Perthshire</asp:ListItem>
                    <asp:ListItem>Renfrewshire</asp:ListItem>
                    <asp:ListItem>Ross-shire</asp:ListItem>
                    <asp:ListItem>Roxburghshire</asp:ListItem>
                    <asp:ListItem>Selkirkshire</asp:ListItem>
                    <asp:ListItem>Shetland</asp:ListItem>
                    <asp:ListItem>Stirlingshire</asp:ListItem>
                    <asp:ListItem>Sutherland</asp:ListItem>
                    <asp:ListItem>West Lothian</asp:ListItem>
                    <asp:ListItem>Wigtownshire</asp:ListItem>
                    <asp:ListItem>Antrim</asp:ListItem>
                    <asp:ListItem>Armagh</asp:ListItem>
                    <asp:ListItem>Down</asp:ListItem>
                    <asp:ListItem>Fermanagh</asp:ListItem>
                    <asp:ListItem>Londonderry</asp:ListItem>
                    <asp:ListItem>Tyrone</asp:ListItem>
                </asp:DropDownList>
                <span style="visibility:hidden">...</span>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Postcode" CssClass="col-md-2 control-label">Postcode</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Postcode" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Postcode"
                    CssClass="text-danger" ErrorMessage="A post code is required." />
            </div>
        </div>

        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="A full name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
