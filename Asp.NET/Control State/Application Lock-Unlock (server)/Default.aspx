﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppLock.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="Label1"></asp:Label>
            <br />
            <br />
            <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>