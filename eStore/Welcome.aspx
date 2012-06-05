<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center">    
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
        <asp:Label ID="lblWelcome" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/MyAds.xml" 
            onadcreated="AdRotator1_AdCreated" />
        <br />
        <br />
        <asp:Label ID="lblAd" runat="server"></asp:Label>
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
</asp:Content>

