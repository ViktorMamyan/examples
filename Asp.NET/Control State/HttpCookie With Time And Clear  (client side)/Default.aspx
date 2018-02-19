<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Http_Cookie.Default" %>

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
            <asp:Button runat="server" ID="SaveCookie" Text="SaveCookie" OnClick="SaveCookie_Click" />
            <asp:Button runat="server" ID="ReadCookie" Text="ReadCookie" OnClick="ReadCookie_Click" />
            <asp:Button runat="server" ID="ClearCookie" Text="ClearCookie" OnClick="ClearCookie_Click" />
        </div>
    </form>
</body>
</html>