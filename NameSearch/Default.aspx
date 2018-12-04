<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        * {
            box-sizing: border-box;
        }

        input[type=text], select, textarea {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            resize: vertical;
        }

        label {
            padding: 12px 12px 12px 0;
            display: inline-block;
        }

        input[type=submit] {
            background-color: #4CAF50;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            float: right;
            margin-top: 10px;
        }

            input[type=submit]:hover {
                background-color: #45a049;
            }

        .container {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }

        .col-10 {
            float: left;
            width: 8%;
            margin-top: 6px;
        }

        .col-90 {
            float: left;
            width: 92%;
            margin-top: 6px;
        }

        /* Clear floats after the columns */
        .row:after {
            content: "";
            display: table;
            clear: both;
        }

        /* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */
        @media screen and (max-width: 600px) {
            .col-10, .col-90, input[type=submit] {
                width: 100%;
                margin-top: 0;
            }
        }
    </style>
</head>
<body>

    <h2>Name Search</h2>

    <div class="container">
        <form runat="server">
            <div class="row">
                <div class="col-10">
                    <label>Input String : </label>
                </div>
                <div class="col-90">
                    <asp:TextBox ID="txtInputstring" runat="server" TextMode="MultiLine" Rows="20"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-10">
                    <label>Enter Name :</label>
                </div>
                <div class="col-90">
                    <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <asp:Button Text="Search" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
            </div>
            <div class="row">
                <div class="col-10">
                </div>
                <div class="col-90">
                    <asp:Label ID="lblName" runat="server" ForeColor="Red">
                    </asp:Label>
                </div>
            </div>
        </form>
    </div>

</body>
</html>
