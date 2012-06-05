<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <div>
        
        <asp:Label ID="lblOrder" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDate" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Table ID="tblSingleOrder" runat="server">
        </asp:Table>
        <br />
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="lblOBT" runat="server" Text="Order Before Tax:"></asp:Label>
        <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="lblTaxOnOrder" runat="server" Text="Tax:"></asp:Label>
        <asp:Label ID="lblTax" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="lblOT" runat="server" Text="Order Total:"></asp:Label>
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        
    </div>
    <div>
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
</asp:Content>

