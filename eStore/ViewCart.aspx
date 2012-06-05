<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 464px;
        }
        .style4
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div style="text-align:left">
            <asp:Menu ID="Menu2" runat="server" BackColor="#E3EAEB" 
                DataSourceID="SiteMapDataSource1" DynamicHorizontalOffset="2" 
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" 
                StaticSubMenuIndent="10px" style="text-align: left">
                <StaticSelectedStyle BackColor="#1C5E55" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                <DynamicMenuStyle BackColor="#E3EAEB" />
                <DynamicSelectedStyle BackColor="#1C5E55" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            </asp:Menu>
        </div>
        <div style="overflow:auto; position:relative; height:275px; width:520px " >
            <asp:Table ID="tblCatalogue" runat="server" Height="275px" 
                HorizontalAlign="Center" Width="498px">
            </asp:Table>
        </div>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style3">
        <asp:Calendar ID="calendarOrder" runat="server" BackColor="White" 
            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
            onselectionchanged="calendarOrder_SelectionChanged" Width="200px">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        </asp:Calendar>
                </td>
                <td class="style4">
                    <asp:Label ID="lblOBT" runat="server" Text="Order Before Tax:"></asp:Label>
                    <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTaxOnOrder" runat="server" Text="Tax:"></asp:Label>
                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblOT" runat="server" Text="Order Total:"></asp:Label>
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
           </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblShippedOn" runat="server" 
            Text="The Goods Will Be Shipped On:"></asp:Label>
        <asp:Label ID="lblShipDate" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnOrder" runat="server" onclick="btnOrder_Click" 
            Text="Process Order" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
</asp:Content>

