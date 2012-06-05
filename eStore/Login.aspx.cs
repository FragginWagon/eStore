using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;

public partial class Login : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the Click event of the cmdProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void cmdProcess_Click(object sender, EventArgs e)
    {
        try
        {
            Customer cust = new Customer();
            cust.Login(txtUsername.Text, txtPassword.Text);

            if (cust.CustomerID > 0)
            {
                Session.Add("CustomerID", cust.CustomerID);
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Username or Password are invalid - Try Again";
            }
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Problem logging in " + ex.Message;
        }

        if (Convert.ToInt32(Session["CustomerID"]) > 0)
            Response.Redirect("~/Welcome.aspx");
    }
}
