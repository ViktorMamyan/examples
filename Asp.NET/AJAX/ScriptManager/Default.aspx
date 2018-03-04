<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:ScriptManager ID="AJAXsm" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="~/Scripts/JavaScript.js" />
                </Scripts>
            </asp:ScriptManager>
            
            <span id="sp" ></span>
        </div>
    </form>
</body>
</html>