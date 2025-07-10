<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCaptcha.aspx.cs" Inherits="LibraryManagement.TestCaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="captchaImage" runat="server" Height="40px" Width="150px" ImageUrl="~/MyCaptcha.aspx"/>
        </div>
    </form>
</body>
</html>
