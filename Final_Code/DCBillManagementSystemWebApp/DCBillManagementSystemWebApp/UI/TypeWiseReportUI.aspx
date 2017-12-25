<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeWiseReportUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TypeWiseReportUI" %>

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
    <form id="form1" runat="server">
         <a href="Index.html">Home</a>
    <div>
       
    <fieldset>
        <legend>Type Wise Report</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="fromDateTextBox" runat="server" TextMode="Date"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="toDateTextBox" runat="server" TextMode="Date"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" /></td>
            </tr>
        </table>
        <asp:GridView ID="typeWiseReportGridView" runat="server"></asp:GridView>
        <table>
            <tr>
                <td>
                    <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" /></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
