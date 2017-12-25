<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DCBillManagementSystemWebApp.UI.TestRequestEntryUI" %>

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
        <asp:TextBox ID="birthdateTextBox" runat="server" TextMode="Date"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label2" runat="server" Text="Mobile Number"></asp:Label>                    
                </td>
                <td>
        <asp:TextBox ID="mobileNumberTextBox" runat="server"></asp:TextBox>                                        
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label4" runat="server" Text="Test Name"></asp:Label>                                        
                </td>
                <td>
                    <asp:DropDownList ID="entryNameDropDownList" runat="server" OnSelectedIndexChanged="entryNameDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>       
                </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Fee"></asp:Label>
                        <asp:TextBox ID="feeShowTextBox" runat="server" Width="110px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="entryAddMessageLabel" runat="server" Text=""></asp:Label></td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="requestTestNameSaveButton" runat="server" Text="Add" OnClick="ShowTestNamesAtGridVButton_Click" /> 
                </td>
            </tr>
        </table>
    <table>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>
                <asp:GridView ID="requestedTestNameGridView" AutoGenerateColumns="False" runat="server"> 
                  <Columns>
                      <asp:TemplateField HeaderText="SL">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Bind("Sl") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Test Name">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Bind("Test") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Fee">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Bind("Fee") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>  

                </asp:GridView>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                <asp:TextBox ID="totalTextBox" runat="server" Width="114px" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:Label ID="entrySaveMessageLabel" runat="server" Text=""></asp:Label>
                <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
            </td>
        </tr>
    </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
