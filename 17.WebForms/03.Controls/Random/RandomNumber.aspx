<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumber.aspx.cs" Inherits="RandomNumberGenerator.RandomNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <form id="randomNumberForm" runat="server" class="form-horizontal col-md-6 col-md-offset-3" >
            <div class=" form-group">
                <label for="MinNumber">Min Number</label>
                <input id="MinNumber" type="number" runat="server" />
            </div>
            <div class="form-group">
                <label for="MaxNumber">Max Number</label>
                <input id="MaxNumber" type="number" runat="server" />
            </div>
            <div class="form-group">
                <label for="Result">Result</label>
                <input id="Result" type="text" runat="server" />
            </div>
            <div class="form-group">
                <button class="btn-success" id="ButtonRandom" onserverclick="ButtonRandom_Click" runat="server">Get Random Number</button>
            </div>
        </form>
    </div>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
