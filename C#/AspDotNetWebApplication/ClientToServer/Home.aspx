<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClientToServer.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox id="name" runat="server"></asp:TextBox>
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            <asp:TextBox ID="adult" runat="server"></asp:TextBox>
            <asp:Button id="Button" runat="server" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
