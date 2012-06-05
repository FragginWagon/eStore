<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateProfile.aspx.cs" Inherits="UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 0 auto 0 auto">
        <div style="text-align:left">
            <asp:Menu ID="Menu2" runat="server" BackColor="#E3EAEB" 
                DataSourceID="SiteMapDataSource1" DynamicHorizontalOffset="2" 
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" 
                StaticSubMenuIndent="10px">
                <StaticSelectedStyle BackColor="#1C5E55" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                <DynamicMenuStyle BackColor="#E3EAEB" />
                <DynamicSelectedStyle BackColor="#1C5E55" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            </asp:Menu>
        </div>
        <asp:Wizard ID="wzrdUpdate" runat="server" BackColor="#E6E2D8" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" Height="385px" Width="545px" 
            ActiveStepIndex="2" onfinishbuttonclick="wzrdUpdate_FinishButtonClick">
            <StepStyle BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" 
                BorderWidth="2px" />
            <WizardSteps>
                <asp:WizardStep runat="server" title="Personal">
                    <table style="width:100%; height: 336px;">
                        <tr>
                            <td class="style5" colspan="2">
                                Update Personal Information</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtFirstName" ErrorMessage="First Name Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtLastName" ErrorMessage="Last Name Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtAge" ErrorMessage="Age Is Required">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                    ControlToValidate="txtAge" ErrorMessage="Age Must Be Between 18 &amp; 125" 
                                    MaximumValue="125" MinimumValue="18" Type="Integer">*</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Credit Card"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpDwnCredit" runat="server">
                                            <asp:ListItem Selected="True" Enabled="False">Select A Credit Card</asp:ListItem>
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
                    <table style="width:100%; height: 339px;">
                        <tr>
                            <td colspan="2" class="style4">
                                Update Address Information</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="# And Street Address"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtAddress1" ErrorMessage="Street Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtCity" ErrorMessage="City Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Postal Code"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostal" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txtPostal" ErrorMessage="Postal Code Is Required">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtPostal" ErrorMessage="Postal Code Formatting Is Horrible" 
                                    ValidationExpression="[a-zA-z]\d[a-zA-Z]-\d[a-zA-Z]\d">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Region"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtRegion" ErrorMessage="Region Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
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
                    </table>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Account">
                    <table style="width:100%; height: 340px;">
                        <tr>
                            <td class="style3" colspan="2">
                                Update Account Information</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Username"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="txtUsername" ErrorMessage="Username Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Email Is Required">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Email Formatting Is Horrible" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Password Is Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Confirm Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPW" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                    ControlToValidate="txtConfirmPW" 
                                    ErrorMessage="Password Confirmation Is Required">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txtConfirmPW" ControlToValidate="txtPassword" 
                                    ErrorMessage="Passwords Do Not Match">*</asp:CompareValidator>
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
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>

