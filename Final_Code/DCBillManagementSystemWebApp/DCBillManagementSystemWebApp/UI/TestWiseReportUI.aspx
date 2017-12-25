<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReportUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TestWiseReportUI" %>

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
                <legend>Test wise Report</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="fromDateLabel" runat="server" Text="fromDateLabel"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="fromDateTextBox" runat="server" TextMode="Date"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="toDateLabel" runat="server" Text="To Date"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="toDateTextBox" runat="server" TextMode="Date"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="testWiseReportGridView" runat="server" type="GridView" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" /></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
