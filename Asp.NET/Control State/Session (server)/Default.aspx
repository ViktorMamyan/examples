<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSessions.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="Text1"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="SaveSession" Text="SaveSession" OnClick="SaveSession_Click" />
            <br />
            <br />
            <a href="AnotherPage.aspx">Test Page</a>
        </div>
    </form>
</body>
</html>