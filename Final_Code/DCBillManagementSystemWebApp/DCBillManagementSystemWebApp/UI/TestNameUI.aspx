<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestNameUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TestNameUI" %>

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
            
        }
    </style>
</head>
<body>
    <a href="Index.html">Home</a>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>
            Test Setup
        </legend>
        <table>
            <tr>
                <td>
        <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label>                    
                </td>
                <td>
        <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>                                        
                </td>
                &nbsp;
                <td>
        <asp:Label ID="Label3" runat="server" Text="BDT"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label4" runat="server" Text="Test Type"></asp:Label>                                        
                </td>
                <td>
                    <asp:DropDownList ID="typeDropDownList" runat="server"></asp:DropDownList>       
                </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="nameMessageLabel" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Button ID="NameSaveButton" runat="server" Text="Save" OnClick="NameSaveButton_Click" /> 
                </td>
            </tr>
        </table>
    </fieldset>
    <br/>
    <table>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="nameGridView" runat="server" AutoGenerateColumns="False">
                   <Columns>
                       <asp:TemplateField HeaderText="SL">
                           <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" Text='<%#Bind("Sl") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Test Name">
                           <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" Text='<%#Bind("TestName") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Test Fee">
                           <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" Text='<%#Bind("Fee") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
