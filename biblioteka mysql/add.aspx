<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="biblioteka_mysql.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add book</title>
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
        <asp:Label ID="lHeader" runat="server" Text="Add new book"></asp:Label><br />
        <div id="inputs">
            <asp:Label ID="lAuthors" runat="server" Text="Authors"></asp:Label>
            <asp:TextBox ID="iAuthors" runat="server"></asp:TextBox>
            <asp:Label ID="lTitle" runat="server" Text="Title"></asp:Label>
            <asp:TextBox ID="iTitle" runat="server"></asp:TextBox>
            <asp:Label ID="lReleaseDate" runat="server" Text="ReleaseDate"></asp:Label>
            <asp:TextBox ID="iReleaseDate" runat="server"></asp:TextBox>
            <asp:Label ID="lISBN" runat="server" Text="ISBN"></asp:Label>
            <asp:TextBox ID="iISBN" runat="server"></asp:TextBox>
            <asp:Label ID="lFormat" runat="server" Text="Format"></asp:Label>
            <asp:TextBox ID="iFormat" runat="server"></asp:TextBox>
            <asp:Label ID="lPages" runat="server" Text="Pages"></asp:Label>
            <asp:TextBox ID="iPages" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="lDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="iDescription" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="bAdd" runat="server" Text="Add" OnClick="bAdd_Click1" />
    </form>
</body>
</html>
