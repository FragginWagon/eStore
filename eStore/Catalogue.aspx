<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Catalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function numberChecker(event) {
        // internet explorer
        if (navigator.appName == "Microsoft Internet Explorer") {
            if (event.keyCode < 48 || event.keyCode > 57) {
                alert("I Want Numbers Only!");
                return false;
            }
            else {
                return true;
            }
        }
        else {
            if (event.which < 48 || event.which > 57) {
                alert("I Want Numbers Only!");
                return false;
            }
            else {
                return true;
            }
        }
    }
    </script>
    <style type="text/css">
        .style3
        {
            width: 707px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
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
        <br />
        <div style="overflow:auto; position:relative; height:275px; width:520px " >
            <asp:Table ID="tblCatalogue" runat="server" Height="275px" 
                HorizontalAlign="Center" Width="498px">
            </asp:Table>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
        </div>    
            
            

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width:100%;">
            <tr>
                <td class="style3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <br />
                            <br />
                            <asp:Button ID="btnOrder" runat="server" onclick="btnOrder_Click" 
                                Text="Add To Cart" />
                            <br />
                            <br />
                            <div style="text-align:right">
                            <asp:Label ID="lblStatus" runat="server" style="text-align:right"></asp:Label>
                            </div>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
        <asp:Button ID="btnViewCart" runat="server" onclick="btnViewCart_Click" 
            Text="View Cart" style="text-align: left" />
            
                </td>
                
            </tr>
            </table>
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
    </div>
</asp:Content>

