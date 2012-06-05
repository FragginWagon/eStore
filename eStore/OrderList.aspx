<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <br />
    <asp:DataList ID="dlstOrders" runat="server" 
        onselectedindexchanged="dlstOrders_SelectedIndexChanged">
        <ItemTemplate>
            <a href="OrderDetails.aspx?OrderID=<%# DataBinder.Eval(Container.DataItem, "OrderID")%>&OrderDate=<%# DataBinder.Eval(Container.DataItem, "OrderDate")%>">
                <%# DataBinder.Eval(Container.DataItem, "OrderID")%>
            </a>&nbsp;
            <%# DataBinder.Eval(Container.DataItem, "OrderDate")%>
        </ItemTemplate>
    </asp:DataList>
    </div>
<div>
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
</asp:Content>