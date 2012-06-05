using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;
using System.Data;

public partial class Catalogue : System.Web.UI.Page
{


    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerID"] == null)
            Server.Transfer("~/Login.aspx");
        else
        {
            if (Session["Cart"] == null) // haven't been to db yet
            {
                try
                {
                    Product myProds = new Product();
                    DataTable myTable = myProds.GetProdInfoForCatalogue();
                    lblStatus.Text = " &nbsp;";
                    if (!myTable.HasErrors)
                    {
                        CartItem[] myCart = new CartItem[myTable.Rows.Count];
                        int ctr = 0;
                        // build CartItem Array From DataTable contents
                        foreach (DataRow dr in myTable.Rows)
                        {
                            CartItem item = new CartItem();
                            item.ProdCd = (String)dr["prodcd"];
                            item.ProdName = (String)dr["prodnam"];
                            item.Graphic = (String)dr["graphic"];
                            item.Msrp = (Decimal)dr["msrp"];
                            item.Qty = 0;
                            myCart[ctr++] = item;
                        }

                        Session["Cart"] = myCart; // load to session
                        LoadDetails();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Catalogue Problem - " + ex.Message;
                }
            }
            else
            {
                if (!Page.IsPostBack) // skip db load
                    LoadDetails();
                //else
                    //AddToCart();
            }
        }
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
                     
            try
            {
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
                    txtqty.Attributes.Add("onkeypress", "return numberChecker( event );");
                    //txtqty.AutoPostBack = true;
                    txtqty.Text = Convert.ToString(item.Qty);
                    txtqty.MaxLength = 3;
                    txtqty.Width = new System.Web.UI.WebControls.Unit(25);
                    td.Controls.Add(txtqty);
                    tr.Cells.Add(td);


                    tblCatalogue.Rows.Add(tr); // add row
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
    /// Adds to cart.
    /// </summary>
    protected void AddToCart()
    {
        int ctr = 0;
        int qty = 0;
        CartItem[] Cart;
        String lit;

        Cart = (CartItem[])Session["Cart"];
        foreach (CartItem item in Cart)
        {
            lit = "qty" + ctr++;

            foreach (String srchStr in Request.Form)
            {
                if (srchStr.EndsWith(lit))
                    qty = Convert.ToInt16(Request.Form[srchStr]);
            }

            if (qty >= 0) //update only selected item
                item.Qty = qty;
        }

        Session["Cart"] = Cart; // store updates in session
        lblStatus.Text = "Added!";
        LoadDetails();
    }

    /// <summary>
    /// Handles the Click event of the btnViewCart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnViewCart_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/ViewCart.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        AddToCart();
    }
}
