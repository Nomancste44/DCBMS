<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TestTypeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            width: 400px;
            margin: 0 auto;
        }
        .set {
            margin-top: 100px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="set">
    <a href="Index.html">Home</a>        
    <fieldset>
        <legend>Test Type Setup</legend>
        <table >
            <tr>
            <td>
        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label> 
                </td>
                <td>
        <asp:TextBox ID="typeTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label></td>
                    
                <td colspan="2"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="typeSaveButton" runat="server" Text="Save" OnClick="typeSaveButton_Click" /> </td>
            </tr>
        </table>
        <br/>
        <table>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td>
        <asp:GridView ID="typeGridView" AutoGenerateColumns="False" runat="server">
            
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Bind("Sl") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Bind("TestType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView> 
        </td>
        </tr> 
        </table> 
        </fieldset>
        
    </div>
    </form>
</body>
</html>
