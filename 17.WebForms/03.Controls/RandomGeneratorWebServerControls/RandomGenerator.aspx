<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorWebServerControls.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <div class="container">
        <form id="randomNumberForm" runat="server" class="form-horizontal col-md-6 col-md-offset-3" >
            <asp:Panel class=" form-group" runat="server">
                <asp:Label ID="MinNumberLabel" AssociatedControlID="MinNumber" runat="server" Text="Min Number" />
                <asp:TextBox ID="MinNumber" type="number" runat="server" />
            </asp:Panel>
            <asp:Panel class="form-group" runat="server">
                <asp:Label ID="MaxNumberLabel" AssociatedControlID="MaxNumber" runat="server" Text="Max Number" />
                <asp:TextBox ID="MaxNumber" type="number" runat="server" />
            </asp:Panel>
            <asp:Panel class="form-group" runat="server">
                 <asp:Label ID="ResultLabel" AssociatedControlID="Result" runat="server" Text="Result" />
                <asp:TextBox ID="Result" runat="server" />
            </asp:Panel>
            <asp:Panel class="form-group" runat="server">
                <asp:Button class="btn-success" ID="ButtonRandom" runat="server" Text="Generate Random Number" OnClick="ButtonRandom_Click"/>
            </asp:Panel>
        </form>
    </div>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
