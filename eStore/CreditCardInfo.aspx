<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCardInfo.aspx.cs" Inherits="CreditCardInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align: left">
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
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Card Number"></asp:Label>
&nbsp;</p>
    <p>
        <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtCardNumber" ErrorMessage="Credit Card Number Is Required">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtCardNumber" 
            ErrorMessage="Only Digits For The Credit Card Please" 
            ValidationExpression="\d*">*</asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Card Type"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="drpDwnCreditType" runat="server">
            <asp:ListItem Value="V">Visa</asp:ListItem>
            <asp:ListItem Value="M">Mastercard</asp:ListItem>
            <asp:ListItem Value="A">American Express</asp:ListItem>
            <asp:ListItem Value="D">Discover</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnOrder" runat="server" onclick="btnCmd_Click" 
            Text="Process Order" />
    </p>
    <p>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="The Card Was - "></asp:Label>
        <asp:Label ID="lblCredit" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </p>
</asp:Content>

