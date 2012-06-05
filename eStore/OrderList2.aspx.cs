using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;
using System.Data;

public partial class OrderList2 : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        tblOrderList.Attributes.Add("onclick", "clickOnTable(event)");
        Order myOrder = new Order();
        // Add the data to the page in string variable sXML
        string strXML = myOrder.GetAllOrderDetails(Convert.ToInt32(Session["CustomerID"])).GetXml(); // Get the data
        strXML = strXML.Replace("\r\n", "");
        strXML = strXML.Replace(">    <", "><");
        string script = @"<script type='text/javascript'>var sXML = ";
        script += "\"" + strXML + "\" </script>";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "sXML", script);
        bool colorSwitch = false;
        System.Drawing.Color bgcolor;

        DataTable dt = myOrder.GetOrderNosAndDates(Convert.ToInt32(Session["CustomerID"]));
        if (tblOrderList.Rows.Count == 0)
        {
            lblStatus.Text = "No Orders!!";
        }
        else
        {
            try
            {
                if (Session["CustomerID"] == null)
                    Server.Transfer("~/Login.aspx");
                else
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();

                    if (colorSwitch == false)
                    {
                        bgcolor = bgcolor = System.Drawing.Color.White;
                        colorSwitch = true;
                    }
                    else
                    {
                        bgcolor = bgcolor = System.Drawing.Color.DarkSeaGreen;
                        colorSwitch = false;
                    }

                    td = new TableCell(); // Order ID
                    td.Width = new Unit(30, UnitType.Percentage);
                    td.Font.Name = "Verdana";
                    td.Text = "Order ID";
                    td.ForeColor = System.Drawing.Color.Black;
                    tr.Cells.Add(td);

                    td = new TableCell(); //OrderDate
                    td.Width = new Unit(30, UnitType.Percentage);
                    td.Font.Name = "Verdana";
                    td.Text = "Order Date";
                    td.ForeColor = System.Drawing.Color.Black;
                    tr.Cells.Add(td);

                    tblOrderList.Rows.Add(tr);

                    foreach (DataRow rows in dt.Rows)
                    {
                        if (colorSwitch == false)
                        {
                            bgcolor = bgcolor = System.Drawing.Color.White;
                            colorSwitch = true;
                        }
                        else
                        {
                            bgcolor = bgcolor = System.Drawing.Color.DarkSeaGreen;
                            colorSwitch = false;
                        }

                        tr = new TableRow();


                        td = new TableCell(); // Order ID
                        td.Width = new Unit(15, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = Convert.ToString(rows["orderid"]);
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);

                        td = new TableCell(); //OrderDate
                        td.Width = new Unit(15, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = Convert.ToString(rows["orderdate"]);
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);

                        tblOrderList.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Shit went crazy with the exception: " + ex;
            }
        }
    }
}
