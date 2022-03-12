<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="connect.aspx.cs" Inherits="biblioteka_mysql.connect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Connect to db</title>
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
        <asp:Label ID="lHeader" runat="server" Text="Connect to MYSQL"></asp:Label><br />
        <div id="inputs">
            <asp:Label ID="lServer" runat="server" Text="Server"></asp:Label>
            <asp:TextBox ID="iServer" runat="server">localhost</asp:TextBox>
            <asp:Label ID="lPort" runat="server" Text="Port"></asp:Label>
            <asp:TextBox ID="iPort" runat="server">3310</asp:TextBox>
            <asp:Label ID="lDatabase" runat="server" Text="Database"></asp:Label>
            <asp:TextBox ID="iDatabase" runat="server">library</asp:TextBox>
            <asp:Label ID="lUser" runat="server" Text="User"></asp:Label>
            <asp:TextBox ID="iUser" runat="server">root</asp:TextBox>
            <asp:Label ID="lPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="iPassword" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="bConnect" runat="server" Text="Connect" OnClick="bConnect_Click" /><br />
        <asp:Label ID="lInfo" runat="server" Text="Nie udało się połączyć" Visible="false" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
