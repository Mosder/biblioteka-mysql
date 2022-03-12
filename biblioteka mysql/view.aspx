<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="biblioteka_mysql.view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Books</title>
    <style>
        table, td, th {
            transform: scaleX(-1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="bAddBook" runat="server" Text="Add book" OnClick="bAddBook_Click" />
            <asp:Button ID="bSearchBooks" runat="server" Text="Search books" OnClick="bSearchBooks_Click" />
            <asp:Button ID="bClearFilters" runat="server" Text="Clear filters" OnClick="bClearFilters_Click" />
            <asp:GridView ID="books" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="books_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="bookDelete" Text="Delete" ButtonType="Button" HeaderText="Delete book" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField CommandName="bookEdit" Text="Edit" ButtonType="Button" HeaderText="Edit book" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
