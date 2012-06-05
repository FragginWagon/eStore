using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;
using System.Collections;

public partial class CreditCardInfo : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
    }
    /// <summary>
    /// Handles the Click event of the btnCmd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnCmd_Click(object sender, EventArgs e)
    {
        CreditCardVerify credit = new CreditCardVerify();
        lblCredit.Text = "";
        if (credit.CheckCCNumber(txtCardNumber.Text, drpDwnCreditType.SelectedItem.Value) == "OK")
        {
            int orderID = -1;
            int boFlag = 0;
            Order myOrder = new Order();
            decimal orderTotal = Convert.ToDecimal(Session["OrderTotal"]);
            try
            {
                Hashtable hshRet = myOrder.AddOrder(
                                                    (CartItem[])Session["Cart"],
                                                    Convert.ToInt32(Session["CustomerID"]),
                                                    Convert.ToDecimal(Session["OrderTotal"]),
                                                    Convert.ToDateTime(Session["ShipDate"])
                                                    );
                orderID = Convert.ToInt32(hshRet["orderid"]);
                boFlag = Convert.ToInt32(hshRet["boflag"]);
                String msg = Convert.ToString(hshRet["message"]);
                msg += ", " + Convert.ToString(hshRet["webmessage"]);

                if (orderID > 0) // Order Added
                {
                    lblStatus.Text = "Order " + orderID + " Created!";

                    if (boFlag > 0)
                        lblStatus.Text = lblStatus.Text + " Some goods were backordered!";
                    Session["Cart"] = null;
                }
                else
                    lblStatus.Text = msg + ", try again later!";
                btnOrder.Visible = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Order was not created, try again later! - " + ex.Message;
                btnOrder.Visible = false;
            }
        }
        else
        {
            Label3.Visible = true;
            lblCredit.Text = credit.CheckCCNumber(txtCardNumber.Text, drpDwnCreditType.SelectedItem.Value);
        }
            
    }
}
