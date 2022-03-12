<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="biblioteka_mysql.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        #inputs {
            display: grid;
            grid-template-columns: 1fr 1fr;
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lHeader" runat="server" Text="Login"></asp:Label><br />
        <div id="inputs">
            <asp:Label ID="lEmail" runat="server" Text="Email" Visible="False"></asp:Label>
            <asp:TextBox ID="iEmail" runat="server" Visible="False" TextMode="Email"></asp:TextBox>
            <asp:Label ID="lLogin" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="iLogin" runat="server"></asp:TextBox>
            <asp:Label ID="lPass" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="iPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="bLogin" runat="server" Text="Login" OnClick="bLogin_Click"/><br />
        <asp:Button ID="bChange" runat="server" Text="Register instead" OnClick="bChange_Click"/><br />
        <asp:Label ID="lInfo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
