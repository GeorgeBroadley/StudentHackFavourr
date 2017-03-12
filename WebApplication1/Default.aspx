<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to Favourr</h1>
        <p class="lead">Welcome to FAVOURR where good favourr gain more good favourrs</p>
        <div class="row">
            <div class="col-md-9">
                <asp:DropDownList ID="County" CssClass="form-control" runat="server">
                    <asp:ListItem>All</asp:ListItem>
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
            </div>
            <div class="col-md-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default btn-block" Text="Filter Results" OnClick="Button1_Click" />
            </div>
        </div>
           
        <div style="width:100%;padding-left:calc((100% - 1000px) / 2);padding-right:calc((100% - 1000px) / 2);padding-top:10px;">
            <asp:ImageButton ID="accounting" ImageUrl="Content/coins-1015125_640.jpg" runat="server" Height="140px" Width="200px" OnClick="accounting_Click" style="float:left;clear:left" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="tech" ImageUrl="Content/ipad-606766_640.jpg" runat="server" Height="140px" Width="200px" OnClick="tech_Click" style="float:left" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="garden" ImageUrl="Content/lawnmower-384589_640.jpg" runat="server" Height="140px" Width="200px" OnClick="garden_Click" style="float:left" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="decor" ImageUrl="Content/old-paint-brush-1061955_640.jpg" runat="server" Height="140px" Width="200px" OnClick="decor_Click" style="float:left" />
            <!--OnClick="ImageButton_Click"-->

            <asp:ImageButton ID="mech" ImageUrl="Content/mercedes-benz-1461507_640.jpg" runat="server" Height="140px" Width="200px" OnClick="mech_Click" />
            <!--OnClick="ImageButton_Click"-->
        </div>
    </div>
    
    <asp:Panel CssClass="alert alert-danger" ID="LogWarn" runat="server" role="alert" Visible="False" >
        You need to log in to claim Favourrs
    </asp:Panel>

    <div class="row">
        <asp:Panel ID="favoursTable" runat="server"></asp:Panel>
    </div>
</asp:Content>