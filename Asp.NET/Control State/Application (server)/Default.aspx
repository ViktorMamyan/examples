<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Application_State.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="counter"></asp:Label>
            <br />
            <br />
            <asp:Button runat="server" ID="AddOne" Text="+1" OnClick="AddOne_Click" />
            <asp:Button runat="server" ID="AddTwo" Text="+2" OnClick="AddTwo_Click" />
        </div>
    </form>
</body>
</html>