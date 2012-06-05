<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MasterPageFile="~/MasterPage.master" Title="Register" %>


  
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" Runat="Server">
        <div style="text-align:center">
    
                <asp:Wizard ID="wzrdRegister" runat="server" ActiveStepIndex="1" BackColor="#E6E2D8" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    Font-Names="Verdana" Font-Size="0.8em" Height="296px" 
                    onfinishbuttonclick="Wizard1_FinishButtonClick" 
                    Width="591px">
                    <StepStyle BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" 
                        BorderWidth="2px" />
                    <WizardSteps>
                        <asp:WizardStep runat="server" title="Personal">
                            <table style="width: 100%; height: 212px;">
                                <tr>
                                    <td colspan="2" align="center" class="style1">
                                        Personal Information</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="txtFirstName" ErrorMessage="First Name Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="txtLastName" ErrorMessage="Last Name Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label3" runat="server" Text="Age:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                            ControlToValidate="txtAge" ErrorMessage="Age Must Be From 18 - 125">*</asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                            ControlToValidate="txtAge" ErrorMessage="Age Is Unacceptable" 
                                            MaximumValue="125" MinimumValue="18" Type="Integer">*</asp:RangeValidator>
                                    </td>
                                                                   </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label4" runat="server" Text="Credit Card:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpDwnCredit" runat="server">
                                            <asp:ListItem Selected="True">Select A Credit Card</asp:ListItem>
                                            <asp:ListItem>MasterCard</asp:ListItem>
                                            <asp:ListItem>Visa</asp:ListItem>
                                            <asp:ListItem Value="AMEX">American Express</asp:ListItem>
                                            <asp:ListItem>Discover</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                                                   </tr>
                            </table>
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" title="Address">
                            <table style="width:100%; height: 213px;">
                                <tr>
                                    <td colspan="2" align="center" class="style1">
                                        Address Information</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label5" runat="server" Text="# And Street:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                            ControlToValidate="txtAddress1" ErrorMessage="Street Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label6" runat="server" Text="City:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                            ControlToValidate="txtCity" ErrorMessage="City Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label7" runat="server" Text="Region:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                            ControlToValidate="txtRegion" ErrorMessage="Region is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label8" runat="server" Text="Country:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpDwnCountry" runat="server">
                                            <asp:ListItem Enabled="False" Selected="True">Select A Country</asp:ListItem>
                                            <asp:ListItem>USA</asp:ListItem>
                                            <asp:ListItem>Canada</asp:ListItem>
                                            <asp:ListItem>Cambodia</asp:ListItem>
                                            <asp:ListItem>Brazil</asp:ListItem>
                                            <asp:ListItem>Mexico</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label9" runat="server" Text="Postal Code:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                            ControlToValidate="txtPostalCode" ErrorMessage="Postal Code Is Required">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="txtPostalCode" 
                                            ErrorMessage="Formatting Of Postal Code Is Horrible!" 
                                            ValidationExpression="[a-zA-z]\d[a-zA-Z]-\d[a-zA-Z]\d">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" Title="Account">
                            <table style="width:100%; height: 214px;">
                                <tr>
                                    <td colspan="2" align="center" class="style1">
                                        Account Information</td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label10" runat="server" Text="Username:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtUsername" ErrorMessage="Field Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label11" runat="server" Text="Email Address:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtEmail" ErrorMessage="Field is Required">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txtEmail" ErrorMessage="Email Formating is Horrible" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label12" runat="server" Text="Password:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" style="height: 22px" 
                                            TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtPassword" ErrorMessage="Field Is Required">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label13" runat="server" Text="Confirm PW:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="txtPasswordConfirm" ErrorMessage="Field Is Required">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtPasswordConfirm" ControlToValidate="txtPassword" 
                                            ErrorMessage="Passwords Don't Match">*</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                    </WizardSteps>
                    <SideBarButtonStyle ForeColor="White" />
                    <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                        ForeColor="#1C5E55" />
                    <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" 
                        Width="25%" />
                    <HeaderStyle BackColor="#666666" BorderColor="#E6E2D8" BorderStyle="Solid" 
                        BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
                        HorizontalAlign="Center" />
                </asp:Wizard>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <br />
                </div>
                <div style="text-align:center">
    
    
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    
    </div>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style3
        {
            font-size: x-small;
            font-weight: bold;
            width: 87px;
        }
    </style>

</asp:Content>

