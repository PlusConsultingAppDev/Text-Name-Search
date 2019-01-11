<%@ Page Title="Search Employee" Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="EmployeeSearch._Default" %>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">--%>

<form id="form1" runat="server">
    <div>
        <span>
            <label>First Name&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; </label>
            <asp:textbox id="TextBox1" runat="server"></asp:textbox>
            <br />
        </span>
    </div>
    <div>
        <span>
            <label>Middle Name :&nbsp;&nbsp;&nbsp;&nbsp; </label>
            <asp:textbox id="TextBox2" runat="server"></asp:textbox>
            <br />
        </span>
    </div>
    <div>
        <span>
            <label>Last Name&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; </label>
            <asp:textbox id="TextBox3" runat="server"></asp:textbox>
            <br />
            <br />
        </span>

    </div>

    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button runat="server" text="Search" id="btnSearch" onclick="Search_Click" />
    </div>
    <br />
    <div>
        <asp:gridview id="gvResultData" runat="server">
            <%-- <Columns>
        <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="150px" />
        <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" ItemStyle-Width="100px" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Count" HeaderText="Count" ItemStyle-Width="100px" />
    </Columns>--%>
    </asp:gridview>
    </div>
</form>

<%--<asp:Table ID="Table1" runat="server"></asp:Table>--%>

<%--</asp:Content>--%>
