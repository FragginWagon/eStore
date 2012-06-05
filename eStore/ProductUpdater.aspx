<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductUpdater.aspx.cs" Inherits="ProductUpdater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
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
    <asp:GridView ID="grdVwProducts" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        onpageindexchanging="grdVwProducts_PageIndexChanging" 
        onrowcancelingedit="grdVwProducts_RowCancelingEdit" 
        onrowediting="grdVwProducts_RowEditing" 
        onrowupdating="grdVwProducts_RowUpdating" 
        onsorting="grdVwProducts_Sorting" PageSize="5" 
        onselectedindexchanged="grdVwProducts_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField ReadOnly="True" DataField="prodcd" SortExpression="prodcd" HeaderText="Product Code" />
            <asp:BoundField DataField="prodnam" SortExpression="prodnam" HeaderText="Product Name" />
            <asp:BoundField DataField="graphic" SortExpression="graphic" HeaderText="Graphic" />
            <asp:BoundField DataField="costprice" SortExpression="costprice" HeaderText="Cost" HtmlEncode="false" DataFormatString="{0:c2}" />
            <asp:BoundField DataField="msrp" SortExpression="msrp" HeaderText="MSRP" HtmlEncode="False" DataFormatString="{0:c2}" />
            <asp:BoundField DataField="qoh" SortExpression="qoh" HeaderText="QOH" />
            <asp:BoundField DataField="qob" SortExpression="qob" HeaderText="QOB" />
            <asp:CommandField ShowEditButton="True" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
</asp:Content>

