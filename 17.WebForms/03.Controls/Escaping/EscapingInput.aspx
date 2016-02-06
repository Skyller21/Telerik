<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapingInput.aspx.cs" Inherits="Escaping.EscapingInput" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Input text" ID="TextLabel" runat="server" AssociatedControlID="Text"/>
        <asp:TextBox ID="Text" runat="server" />
        <asp:Button ID="Button" Text="Submit" runat="server" OnClick="Button_Click"/>
        <asp:Label ID="TextArea" runat="server" />
    </form>
</body>
</html>
