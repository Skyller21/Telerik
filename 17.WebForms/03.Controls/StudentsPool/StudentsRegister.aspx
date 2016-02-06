<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsRegister.aspx.cs" Inherits="StudentsPool.StudentsRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Students</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="col-lg-6">
        <div class="well bs-component">
            <form class="form-horizontal" id="form1" runat="server">
                <fieldset>
                    <legend>Register</legend>
                    <asp:Panel class="form-group" runat="server">
                        <asp:Label AssociatedControlID="FirstName" class="col-lg-2 control-label" Text="First Name" runat="server" />
                        <asp:Panel class="col-lg-10" runat="server">
                            <asp:TextBox type="text" class="form-control" ID="FirstName" placeholder="First Name" runat="server" />
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel class="form-group" runat="server">
                        <asp:Label AssociatedControlID="LastName" class="col-lg-2 control-label" Text="Last Name" runat="server" />
                        <asp:Panel class="col-lg-10" runat="server">
                            <asp:TextBox type="text" class="form-control" ID="LastName" placeholder="Last Name" runat="server" />
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel class="form-group" runat="server">
                        <asp:Label AssociatedControlID="FacultyNumber" class="col-lg-2 control-label" Text="Faculty Number" runat="server" />
                        <asp:Panel class="col-lg-10" runat="server">
                            <asp:TextBox type="text" class="form-control" ID="FacultyNumber" placeholder="Faculty Number" runat="server" />
                        </asp:Panel>
                    </asp:Panel>


                    <div class="form-group">
                        <asp:Label AssociatedControlID="DropDownListUniversities" class="col-lg-2 control-label" Text="University" runat="server" />
                        <div class="col-lg-10">
                            <asp:DropDownList ID="DropDownListUniversities" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownListUniversities_SelectedIndexChanged" SelectMethod="GetUniversities" />

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="DropDownListSpecialties" class="col-lg-2 control-label" Text="Specialty" runat="server" />
                        <div class="col-lg-10">
                            <asp:DropDownList ID="DropDownListSpecialties" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="DropDownListSpecialties_SelectedIndexChanged" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="ListBoxCourses" class="col-lg-2 control-label" Text="University" runat="server" />
                        <div class="col-lg-10">
                            <asp:ListBox ID="ListBoxCourses" runat="server" AutoPostBack="True" SelectionMode="Multiple"
                                OnSelectedIndexChanged="ListBoxCourses_SelectedIndexChanged" Height="70px" SelectMethod="GetCourses" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button type="reset" class="btn btn-default" runat="server" Text="Cancel" />
                            <asp:Button ID="RegBtn" type="submit" class="btn btn-primary" runat="server" Text="Register" OnClick="RegBtn_Click" />
                        </div>
                    </div>
                </fieldset>
            </form>

            <h2>Result</h2>
            <asp:Literal Mode="Encode" ID="Name" runat="server" />
            <br />
            <asp:Literal Mode="Encode" ID="Number" runat="server" />
            <br />
            <asp:Literal Mode="Encode" ID="UniSpec" runat="server" />
            <br />
            <asp:Literal Mode="Encode" ID="SelectedCourses" runat="server" />
        </div>
    </div>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
