using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;
using System.Data;
using System.Collections;

public partial class ViewCart : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDetails();

        if (calendarOrder.SelectedDate < calendarOrder.TodaysDate)
            calendarOrder.SelectedDate = calendarOrder.TodaysDate;

        lblShipDate.Text = calendarOrder.SelectedDate.ToShortDateString();
    }
    /// <summary>
    /// Handles the SelectionChanged event of the calendarOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void calendarOrder_SelectionChanged(object sender, EventArgs e)
    {
        if (calendarOrder.SelectedDate < calendarOrder.TodaysDate)
            calendarOrder.SelectedDate = calendarOrder.TodaysDate;

        lblShipDate.Text = calendarOrder.SelectedDate.ToShortDateString();
    }

    /// <summary>
    /// Loads the details.
    /// </summary>
    protected void LoadDetails()
    {
        CartItem[] cart;
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        if (Session["Cart"] != null) // Haven't been to db yet
        {
            TextBox txtqty;
            cart = (CartItem[])Session["Cart"];
            int count = 0;
            System.Drawing.Color bgcolor;
            System.Web.UI.WebControls.Image pic;
            bool colorSwitch = false;
            double amt = 0;
            double orderTotal2 = 0;

            try
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

                tblCatalogue.Rows.Add(tr); // add row
                foreach (CartItem item in cart)
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

                    if (item.Qty <= 0)
                    {

                    }
                    else
                    {
                        orderTotal2 = 0;

                        // details from cart
                        txtqty = new TextBox();
                        tr = new TableRow();
                        tr.BackColor = bgcolor;

                        td = new TableCell(); // product code
                        td.Width = new Unit(15, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = item.ProdCd;
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);

                        td = new TableCell(); // product name
                        td.Width = new Unit(43, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = item.ProdName;
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);

                        td = new TableCell(); // product graphic
                        pic = new System.Web.UI.WebControls.Image();
                        pic.ImageUrl = "img/catalogue/" + item.Graphic;
                        td.Width = new Unit(15, UnitType.Percentage);
                        td.HorizontalAlign = HorizontalAlign.Center;
                        td.Controls.Add(pic);
                        tr.Cells.Add(td);

                        td = new TableCell(); // price
                        td.Width = new Unit(17, UnitType.Percentage);
                        td.HorizontalAlign = HorizontalAlign.Right;
                        td.Font.Name = "Verdana";
                        td.Text = String.Format("{0:C}", Convert.ToDecimal(item.Msrp));
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);
                     

                        td = new TableCell(); // qty
                        td.HorizontalAlign = HorizontalAlign.Center;
                        txtqty.ID = "qty" + Convert.ToString(count++);
                        txtqty.AutoPostBack = true;
                        txtqty.Text = Convert.ToString(item.Qty);
                        txtqty.MaxLength = 3;
                        txtqty.Width = new System.Web.UI.WebControls.Unit(25);
                        td.Controls.Add(txtqty);
                        tr.Cells.Add(td);

                        orderTotal2 += Convert.ToDouble(item.Msrp) * Convert.ToDouble(item.Qty);
                        amt += orderTotal2;

                        td = new TableCell(); // Total per product
                        td.Width = new Unit(20, UnitType.Percentage);
                        td.Font.Name = "Verdana";
                        td.Text = String.Format("{0:C}", orderTotal2);
                        td.ForeColor = System.Drawing.Color.Black;
                        tr.Cells.Add(td);
                        
                        tblCatalogue.Rows.Add(tr); // add row
                    }// if
                }// for

                
                //insert taxes and totals here
                lblOrderTotal.Text = String.Format("{0:C}", amt);
                lblTax.Text = String.Format("{0:C}", amt * 0.13);
                lblTotal.Text = String.Format("{0:C}", amt * 1.13);
                Session["OrderTotal"] = Convert.ToString(amt * 1.13);
                Session["ShipDate"] = lblShipDate.Text;

                if ((amt * 1.13) > Convert.ToDouble(Application["MaximumOrderAmt"]))
                {
                    lblStatus.Text = "Maximum order amount exceeded, change your order";
                    btnOrder.Visible = false;
                }

            }
            catch (Exception ex)
            {
                tr = new TableRow();
                td = new TableCell();
                td.Text = "Problem Getting Catalogue Info " + ex.Message;
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Server.Transfer("CreditCardInfo.aspx");        
    }
}
