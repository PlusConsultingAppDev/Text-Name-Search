<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextSearch.aspx.cs" Inherits="Text_Name_Search.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Text Search</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Text Search</h2>
        <div>
            <label for="txtSearch">Enter text to search for names:</label>
            <asp:Textbox ID="txtSearch" runat="server"></asp:Textbox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"/>
        </div>
    </div>
    <asp:Panel ID="pnlResults" Visible="false" runat="server">
        <h2>Results</h2>
        <asp:Repeater runat="server" ID="rptResults">
            <ItemTemplate>
                <%#Eval("name") %>:
                <%#Eval("occurrences") %>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    </form>
</body>
</html>
