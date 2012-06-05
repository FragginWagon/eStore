using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;

public partial class Welcome : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                Customer objWebCust = new Customer();

                objWebCust.GetNames(Convert.ToInt32(Session["CustomerID"]));
                lblWelcome.Text = "Welcome " + objWebCust.FirstName + " "
                                             + objWebCust.LastName;
            }
        }
    }

    /// <summary>
    /// Handles the AdCreated event of the AdRotator1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.AdCreatedEventArgs"/> instance containing the event data.</param>
    protected void AdRotator1_AdCreated(object sender, AdCreatedEventArgs e)
    {
        lblAd.Text = e.AlternateText;
    }
}
