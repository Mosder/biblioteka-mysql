<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="biblioteka_mysql.view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="bAddBook" runat="server" Text="Add book" OnClick="bAddBook_Click" />
            <asp:GridView ID="books" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
