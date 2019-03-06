<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">

  <title>Text Name Search</title>
  <link href="styles/main.min.css" rel="stylesheet" />
</head>
<body>
  <form id="form" runat="server">
  <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
  <main class="grid-container">

    <!-- Input text form -->
    <div class="grid-item-left">
      <div class="site-header">
        <h1 class="header">Text</h1>
      </div>
      <div class="input-form">
        <textarea id="InputText" class="input" placeholder="Enter text to search..." spellcheck="false" runat="server"></textarea>
      </div>
    </div>

    <!-- Add employees -->
    <div class="grid-item-middle">
      <div class="site-header">
        <h1 class="header">Name</h1>
      </div>
      <div class="user-form">
        <select class="dropdown" name="dropdown" >
          <option value="employee">Employee Name Search</option>
        </select>
        <input id="firstname" class="field" type="text" placeholder="First Name" />
        <input id="middlename" class="field" type="text" name="middlename" placeholder="Middle Name" />
        <input id="lastname" class="field" type="text" name="lastname" placeholder="Last Name" />
        <input id="add-button" class="submit submit-button" type="button" value="Add Employee" />
        <span id="error" class="error">First, middle, and last name are required.</span>
      </div>
      <ul id="list" class="user-list"></ul>
    </div>

    <!-- Display Results -->
    <div class="grid-item-right">
      <div class="site-header">
        <h1 class="header">Search</h1>
      </div>
      <asp:UpdatePanel ID="UpdatePanel" runat="server">
      <ContentTemplate>
      <div class="results-display">
        <asp:Button id="InitializeSearch" class="submit submit-button" OnClick="SubmitButton_Click" OnClientClick="sendEmployees()" type="button" Text="Initalize Search" runat="server" UseSubmitBehavior="False" />
        <asp:GridView id="ResultsGrid" class="results-table" AutoGenerateColumns="false" GridLines="None" runat="server">
          <Columns>
            <asp:BoundField DataField="Employee Name" HeaderText="Employee Name" />
            <asp:BoundField DataField="Variations Found" HeaderText="Variations Found" />
            <asp:BoundField DataField="Occurrences" HeaderText="Occurrences" />
          </Columns>
        </asp:GridView>
      </div>
      </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </main>
  </form>

  <script src="scripts/index.js"></script>
</body>
</html>