<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnotherPage.aspx.cs" Inherits="WebSessions.AnotherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TextSession"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="DropSession" Text="Drop Session" OnClick="DropSession_Click" />
        </div>
    </form>
</body>
</html>