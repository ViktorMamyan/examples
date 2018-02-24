<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CTRL.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--TextBox Control Properties-->

            <asp:TextBox runat="server" TextMode="SingleLine"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="MultiLine"
                Rows="7" ReadOnly="true" ToolTip="Some text" AutoPostBack="false"
                MaxLength="25"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Color"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Date"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="DateTime"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="DateTimeLocal"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Email"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Month"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Number"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Phone"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Range"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Search"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Time"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Url"></asp:TextBox><br />
            <asp:TextBox runat="server" TextMode="Week"></asp:TextBox><br />
        </div>
    </form>
</body>
</html>