<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderList2.aspx.cs" Inherits="OrderList2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .itemSelected
        {
            font-weight: bold;
            font-size: 10px;
            color: black;
            font-family: verdana;
            background-color: yellow;
        }
        .defItem
        {
            font-size: 10px;
            margin: 1px;
            font-family: verdana;
        }
        .tblItemHead
        {
            font-weight: bold;
            font-size: 12px;
            font-family: verdana;
            background-color: silver;
        }
        .tblItemBigHead
        {
            font-weight: bold;
            font-size: 15px;
            font-family: verdana;
            color: white;
            background-color: blue;
        }
        .itemData
        {
            font-weight: bold;
            font-size: 10px;
            font-family: verdana;
            background-color: white;
        }
        tr
        {
            font-size: 10px;
            margin: 1px;
            font-family: verdana;
        }
    </style>
    
    <script type="text/javascript">
        var oldElem                                // global scoped variables        
        var xmlDocument;
        var collNotes;
        var myWindow;
        var tbl;

        // obtained from the internet unknown source
        function cur(num) {
            num = num.toString().replace(/\$|\,/g, '');
            if (isNaN(num))
                num = "0";
            sign = (num == (num = Math.abs(num)));
            num = Math.floor(num * 100 + 0.50000000001);
            cents = num % 100;
            num = Math.floor(num / 100).toString();
            if (cents < 10)
                cents = "0" + cents;
            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
            return (((sign) ? '' : '-') + '$' + num + '.' + cents);
        }  

        //	Click event handler
        function clickOnTable(e) {
            e = window.event || e;
            var oElem = e.target || e.srcElement;

            //	Selected style is applied - className = "itemSelected"
            //	Default style is applied to previously selected item
            if (oldElem != null)
                oldElem.className = "defItem";                        // reset old row, nothing 1st time

            if (navigator.appName == "Microsoft Internet Explorer") {
                m_selectedRow = oElem.parentElement;                 // IE new row - cell's parent = <tr>
                xmlDocument = new ActiveXObject("Microsoft.XMLDOM");
                xmlDocument.async = "false";
                xmlDocument.loadXML(sXML);
                //orderID = m_selectedRow.getElementTagName("td").item(0);

            } else {
                m_selectedRow = oElem.parentNode;          // FF new row - cell's parent = <tr>
                parser = new DOMParser();
                xmlDocument = parser.parseFromString(sXML, "text/xml");
            }

            if (oElem.tagName == "TD") {                   // make sure they clicked on a cell in a row
                m_selectedRow.className = "itemSelected";  // style = bold and yellow
                oldElem = m_selectedRow;                   // store it for next click 
                getUserDataFromSelection(m_selectedRow);   // process individual cells	
            }
        }

        // Process the cells of the selected row
        function getUserDataFromSelection(selection) {
            var cell = selection.getElementsByTagName("td").item(0);
            var cell2 = selection.getElementsByTagName("td").item(1);
            
            if (navigator.appName == "Microsoft Internet Explorer") {
                noteNumber = cell.innerText//.substring(6, 5, 1);
                dateNumber = cell2.innerText
                collNotes = xmlDocument.selectNodes("//orderdeets");              // all note nodes IE
            } else {
                noteNumber = cell.textContent; //.substring(6, 5, 1);
                dateNumber = cell2.textContent;
                collNotes = xmlDocument.getElementsByTagName("orderdeets");       // all note nodes FF
            }

            if (!myWindow || myWindow.closed) {                             // popup
                myWindow = window.open("", "myWindow", "menubar,resizable,dependent,status,width=640,height=140,left=200,bottom=100");
                myWindow.document.writeln("<html><title>Order Display</title><head>");
                myWindow.document.writeln("<style type='text/css'>");
                myWindow.document.writeln(".tblItemHead { FONT-WEIGHT: bold; FONT-SIZE: 12px;  FONT-FAMILY: verdana ; BACKGROUND-COLOR: silver;}");
                myWindow.document.writeln(".tblItemBigHead { FONT-WEIGHT: bold; FONT-SIZE: 15px; FONT-FAMILY: verdana; COLOR: white; BACKGROUND-COLOR: blue }");
                myWindow.document.writeln(".itemData {  FONT-WEIGHT: bold; FONT-SIZE: 10px; FONT-FAMILY: verdana; BACKGROUND-COLOR: white; }");
                myWindow.document.writeln("</style></head><body></body></html>");
                tbl = null;
                tbl = myWindow.document.createElement("table"); //added to new window
                tbl.border = 3;
                tbl.width = "85%";
                tbl.align = "center";
            }

            tableBuilder(noteNumber, collNotes);
        }

        function tableBuilder(noteNumber, collNotes) {
            var len = tbl.rows.length

            for (i = 0; i < len; i++) {  // delete old table (if it exists)
                if (tbl.rows.length > 0)
                    tbl.deleteRow(0);
            }

            /*Row-->*/tr = tbl.insertRow(0);
            tr.cellSpacing = 0;
            tr.cellPadding = 0;
            tc = tr.insertCell(0);
            tc.colSpan = 1;
            tc.className = "tblItemBigHead";
            tc.innerHTML = "Order ID # " + noteNumber;
            tc = tr.insertCell(1);
            tr.cellSpacing = 0;
            tr.cellPadding = 0;
            tc.colSpan = 5;
            tc.className = "tblItemBigHead";
            tc.innerHTML = "Date: " + dateNumber;
            tc = tr.insertCell(2);
            /*Row-->*/tr = tbl.insertRow(1);
            tc = tr.insertCell(0);
            tc.width = "40%";
            tc.align = "center";
            tc.className = "tblItemHead";
            tc.innerHTML = "Product Name";
            tc = tr.insertCell(1);
            tc.className = "tblItemHead";
            tc.width = "20%";
            tc.align = "center";
            tc.innerHTML = "Sell Price";
            tc = tr.insertCell(2);
            tc.className = "tblItemHead";
            tc.width = "15%";
            tc.align = "center";
            tc.innerHTML = "QtyS";
            tc = tr.insertCell(3);
            tc.className = "tblItemHead";
            tc.width = "15%";
            tc.align = "center";
            tc.innerHTML = "QtyOH";
            tc = tr.insertCell(4)
            tc.className = "tblItemHead";
            tc.width = "20%";
            tc.align = "center";
            tc.innerHTML = "QtyB";
            tc = tr.insertCell(5);
            tc.className = "tblItemHead";
            tc.width = "20%";
            tc.align = "center";
            tc.innerHTML = "Extended Price";
            tc = tr.insertCell(6);
            /*Row--> */tr = tbl.insertRow(2);
            var i2 = 2;
            var i3 = 0;
            var total;
            var orderTotal = 0;
            
            // loop through all notes
            for (i = 0; i < collNotes.length; i++) {
                // select correct note
                
                if (navigator.appName == "Microsoft Internet Explorer") {

                    if (noteNumber == collNotes.item(i).selectSingleNode("orderid").text) {
                        total = parseFloat(collNotes.item(i).selectSingleNode("msrp").text) * parseFloat(collNotes.item(i).selectSingleNode("qtysold").text);
                        orderTotal += total;
                        var tr = tbl.insertRow();
                        tr.className = "itemData";
                        var tc = tr.insertCell();
                        tc.innerText = " ";
                        tc.width = "20%";
                        tc.innerHTML = "<td>" + collNotes.item(i).selectSingleNode("prodnam").text + "</td>";
                        tc = tr.insertCell();
                        tc.align = "center";
                        tc.width = "15%";
                        tc.innerHTML = "<td>" + cur(collNotes.item(i).selectSingleNode("msrp").text) + "</td>";
                        tc = tr.insertCell();
                        tc.width = "15%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes.item(i).selectSingleNode("qtysold").text + "</td>";
                        tc = tr.insertCell();
                        tc.width = "50%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes.item(i).selectSingleNode("qtyordered").text + "</td>";
                        tc = tr.insertCell();
                        tc.width = "20%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes.item(i).selectSingleNode("qtybackordered").text + "</td>";
                        tc = tr.insertCell();
                        tc.width = "20%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + cur(total) + "</td>";
                        tc = tr.insertCell();
                        ++i3;
                        
                    }
                } else {  // firefox
                if (noteNumber == collNotes[i].childNodes[0].firstChild.nodeValue) { // id
                    total = parseFloat(collNotes[i].childNodes[2].firstChild.nodeValue) * parseFloat(collNotes[i].childNodes[3].firstChild.nodeValue);
                        orderTotal += total;
                        tr = tbl.insertRow(i2 + 1);
                        tr.className = "itemData";
                        tc = tr.insertCell(0);
                        tc.innerText = " ";
                        tc.width = "20%";
                        tc.innerHTML = "<td>" + collNotes[i].childNodes[1].firstChild.nodeValue + "</td>"; //from
                        tc = tr.insertCell(1);
                        tc.align = "center";
                        tc.width = "15%";
                        tc.innerHTML = "<td>" + collNotes[i].childNodes[2].firstChild.nodeValue + "</td>";  // to
                        tc = tr.insertCell(2);
                        tc.width = "15%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes[i].childNodes[3].firstChild.nodeValue + "</td>"; // heading
                        tc = tr.insertCell(3);
                        tc.width = "50%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes[i].childNodes[4].firstChild.nodeValue + "</td>"; // notebody
                        tc = tr.insertCell(4);
                        tc.width = "20%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + collNotes[i].childNodes[5].firstChild.nodeValue + "</td>"; // notedate
                        tc = tr.insertCell(5);
                        tc.width = "20%";
                        tc.align = "center";
                        tc.innerHTML = "<td>" + total + "</td>"; // notedate
                        tc = tr.insertCell(6);
                        ++i3;
                    }  // end if
                } // end if
            } // end for
            if (navigator.appName == "Microsoft Internet Explorer") {
                var tr = tbl.insertRow(i2 + i3 + 1)
                var tc = tr.insertCell(0);
                tc.style.textAlign = "right";
                tc.colSpan = 6;
                tc.innerHTML = "<td>" + "<b> Total: " + cur(orderTotal) + "</b><br/>" + "<b> Tax: " + cur(orderTotal * 0.13) + "</b><br/>" + "<b> Order Total: " + cur(orderTotal * 1.13) + "</b>" + "</td>";
                tc = tr.insertCell();
            }
            else {
                var tr = tbl.insertRow(i2 + +i3 + 1)
                var tc = tr.insertCell(0);
                tc.style.textAlign = "right";
                tc.colSpan = 6;
                tc.innerHTML = "<td>" + "<b> Total: " + cur(orderTotal) + "</b><br/>" + "<b> Tax: " + cur(orderTotal * 0.13) + "</b><br/>" + "<b> Order Total: " + cur(orderTotal * 1.13) + "</b>" + "</td>";
                tc = tr.insertCell(1);
            }
            myWindow.document.body.appendChild(tbl); // add table to document
            myWindow.focus();
        }    		            		
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
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
    
    <asp:Table ID="tblOrderList" runat="server">
        <asp:TableRow></asp:TableRow>
        <asp:TableRow></asp:TableRow>
    </asp:Table>
    
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    
        <br />
        <br />
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    
    </div>


</asp:Content>

