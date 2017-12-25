<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        body {
            padding-top: 100px;
            width: 600px;
            margin:  0 auto;
        }
        fieldset {
            
            width: 400px;
            float: left;
        }
    </style>
</head>
<body>
<a href="Index.html">Home</a>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>Payment</legend>
        <fieldset>
            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Bill Number"></asp:Label></td>
                    <td><asp:TextBox ID="billNumberTextBox" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Or"></asp:Label></td>
                </tr>
                  <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Mobile Number"></asp:Label></td>
                    <td><asp:TextBox ID="mobileNumberTextBox" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label></td>
                    <td><asp:TextBox ID="amountTextBox" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="billStatusLabel" runat="server" Text=""></asp:Label></td>
                </tr>
                  <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Due Date"></asp:Label></td>
                    <td><asp:TextBox ID="dueDateTextBox" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click" /></td>
                </tr>
            </table>
        </fieldset>
    </fieldset>
    </div>
    </form>
</body>
</html>
