<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestNameUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TestNameUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>
            Test Request Entry
        </legend>
        <table>
             <tr>
                <td>
        <asp:Label ID="Label5" runat="server" Text="Name of the Patient"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="patientNameTextBox" runat="server"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label1" runat="server" Text="Date Of Birth"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="birthdateTextBox" runat="server"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label2" runat="server" Text="Mobile Number"></asp:Label>                    
                </td>
                <td>
        <asp:TextBox ID="mobileNumberTextBox" runat="server"></asp:TextBox>                                        
                </td>
                &nbsp;
                <td>
        <asp:Label ID="Label3" runat="server" Text="BDT"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label4" runat="server" Text="Test Name"></asp:Label>                                        
                </td>
                <td>
                    <asp:DropDownList ID="entryNameDropDownList" runat="server"></asp:DropDownList>       
                </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Fee"></asp:Label>
                        <asp:TextBox ID="feeShowTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="entryMessageLabel" runat="server" Text=""></asp:Label></td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="NameSaveButton" runat="server" Text="Add" /> 
                </td>
            </tr>
        </table>
    </fieldset>
    <table>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="entryNameGridView" runat="server"></asp:GridView>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="saveButton" runat="server" Text="Save" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
