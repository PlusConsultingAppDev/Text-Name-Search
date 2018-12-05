<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SearchStrings.aspx.vb" Inherits="WebApplication1.SearchStrings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Names Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 600px;">
            In order to find an employee name and the number of occurrences within a text, enter the text content and the employee name
            for which you are searching, in the form below.  Press "search" to display the results. 
            The application will find names in according to any of the following formats, regardless of casing:<br /><br />
            [First Name] [Last Name] <br />
            [First Name] [Middle Initial] [Last Name] <br />
            [First Name] [Middle Initial]. [Last Name] <br />
            [First Name] [Middle Name] [Last Name] <br /><br />
            <div style="padding: 5px;">
                <div style="display: inline-block; vertical-align: top;">
                    <asp:Label runat="server" ID="lblContentToSearch" Text="Text Content To Search: " Width="170"></asp:Label>
                </div>
                <div style="display: inline-block">
                    <asp:TextBox runat="server" ID="txtContentToSearch" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
            </div>
            <div style="padding: 5px;">
                <div style="display: inline-block;">
                    <asp:Label runat="server" ID="lblEmployeeName" Text="Employee Name: " Width="170"></asp:Label>
                </div>
                <div style="display: inline-block;">
                    <asp:TextBox runat="server" ID="txtNameInput"></asp:TextBox>
                </div>
            </div>
            <div style="padding: 5px;">
                <asp:Button runat="server" ID="btnSearch" Text="Search" />
            </div>
        </div>
    </form>
</body>
</html>
