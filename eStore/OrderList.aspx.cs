using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;
using System.Data;

public partial class OrderList : System.Web.UI.Page
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
                Order myOrder = new Order();
                DataTable tbl = myOrder.GetOrderNosAndDates(Convert.ToInt32(Session["CustomerID"]));
                dlstOrders.DataSource = tbl.DefaultView;
                dlstOrders.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Problem getting Order Information, " + ex.Message;
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the dlstOrders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void dlstOrders_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
