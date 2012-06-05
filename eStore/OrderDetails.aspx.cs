using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eStoreWebObjects;

public partial class OrderDetails : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CustomerID"] == null)
                Server.Transfer("~/Login.aspx");
            else
            {
                int oid = Convert.ToInt32(Request.QueryString["OrderID"]);
                DateTime odate = Convert.ToDateTime(Request.QueryString["OrderDate"]);
                lblOrder.Text = "Order#: " + oid;
                lblDate.Text = "Date: " + odate;
                Order myOrder = new Order();
                DataTable tbl = myOrder.OrderDataDetails(Convert.ToInt32(Session["CustomerID"]), oid);

                //OrderItem[] order;
                TableRow tr = new TableRow();
                TableCell td = new TableCell();

                System.Drawing.Color bgcolour;
                decimal orderTotal = 0;
                decimal orderTotal2 = 0;

                try
                {
                    

                    if (tbl.Rows.Count == 0)
                    {
                        Session.Clear();
                        lblStatus.Text = "Sorry This IS NOT your order, you have been disconnected due to your Faggettry";
                        lblDate.Visible = false;
                        lblOrder.Visible = false;
                        lblOrderTotal.Visible = false;
                        lblTax.Visible = false;
                        lblTotal.Visible = false;
                        lblOBT.Visible = false;
                        lblOT.Visible = false;
                        lblTaxOnOrder.Visible = false;
                    }
                    else
                    {
                        td = new TableCell(); // product Name
                        td.Width = new Unit(30, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "Product Name";
                        tr.Cells.Add(td);

                        td = new TableCell(); // Msrp
                        td.Width = new Unit(20, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "Msrp";
                        tr.Cells.Add(td);

                        td = new TableCell(); // Qty Ordered
                        td.Width = new Unit(10, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "Qty Ordered";
                        tr.Cells.Add(td);

                        td = new TableCell(); // Qty Sold
                        td.Width = new Unit(10, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "Qty Sold";
                        tr.Cells.Add(td);

                        td = new TableCell(); // Qty on back-order
                        td.Width = new Unit(10, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "QOB";
                        tr.Cells.Add(td);

                        td = new TableCell(); // Total per product
                        td.Width = new Unit(20, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = "Total per product";
                        tr.Cells.Add(td);

                        tblSingleOrder.Rows.Add(tr); // add row

                        foreach (DataRow rows in tbl.Rows)
                        {
                            orderTotal2 = 0;
                            
                            bgcolour = bgcolour = System.Drawing.Color.DarkSeaGreen;

                            //details from cart
                            tr = new TableRow();
                            tr.BackColor = bgcolour;

                            td = new TableCell(); // product Name
                            td.Width = new Unit(30, UnitType.Percentage);
                            td.Font.Name = "Verdana";
                            td.Text = Convert.ToString(rows["prodnam"]);
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            td = new TableCell(); // Msrp
                            td.Width = new Unit(20, UnitType.Percentage);
                            td.Font.Name = "Verdana";
                            td.Text = String.Format("{0:C}", Convert.ToDecimal(rows["msrp"]));
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            td = new TableCell(); // Qty Ordered
                            td.Width = new Unit(10, UnitType.Percentage);
                            td.Font.Name = "Verdana";
                            td.Text = Convert.ToString(rows["QtyOrdered"]);
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            td = new TableCell(); // Qty Sold
                            td.Width = new Unit(10, UnitType.Percentage);
                            td.HorizontalAlign = HorizontalAlign.Right;
                            td.Font.Name = "Verdana";
                            td.Text = Convert.ToString(rows["QtySold"]);
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            td = new TableCell(); // Qty on back-order
                            td.Width = new Unit(10, UnitType.Percentage);
                            td.HorizontalAlign = HorizontalAlign.Right;
                            td.Font.Name = "Verdana";
                            td.Text = Convert.ToString(rows["QtyBackOrdered"]);
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            orderTotal2 += Convert.ToDecimal(rows["Msrp"]) * Convert.ToDecimal(rows["QtyOrdered"]);
                            orderTotal += orderTotal2;

                            td = new TableCell(); // Total per product
                            td.Width = new Unit(20, UnitType.Percentage);
                            td.Font.Name = "Verdana";
                            td.Text = String.Format("{0:C}", orderTotal2);
                            td.ForeColor = System.Drawing.Color.Black;
                            tr.Cells.Add(td);

                            tblSingleOrder.Rows.Add(tr); // add row
                            
                        }

                        lblOrderTotal.Text = String.Format("{0:C}", orderTotal);
                        lblTax.Text = String.Format("{0:C}", Convert.ToDouble(orderTotal) * 0.13);
                        lblTotal.Text = String.Format("{0:C}", Convert.ToDouble(orderTotal) * 1.13);
                    }
                    
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Problem getting order info " + ex.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Problem getting Order Information, " + ex.Message;
        }
    }
}
