<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGet.aspx.cs" Inherits="WebApi.WebGet" %>

<!DOCTYPE html>
<html>
<head>
    <title>Danh Sách Phim</title>
</head>
<body>
    <h2>Danh Sách Phim</h2>
    
    <!-- Repeater để hiển thị danh sách phim -->
    <asp:Repeater ID="RepeaterMovies" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>Movie ID</th>
                    <th>Title</th>
                    <th>Description</th>
                </tr>
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
                <td><%# Eval("MovieID") %></td>
                <td><%# Eval("Title") %></td>
                <td><%# Eval("Description") %></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</body>
</html>
