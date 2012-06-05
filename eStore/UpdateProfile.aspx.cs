using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;

public partial class UpdateProfile : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    Customer myCust = new Customer();
                    myCust.GetCurrentProfile(Convert.ToInt32(Session["CustomerID"]));
                    txtUsername.Text = myCust.Username;
                    txtFirstName.Text = myCust.FirstName;
                    txtLastName.Text = myCust.LastName;
                    txtEmail.Text = myCust.Email;
                    txtAge.Text = Convert.ToString(myCust.Age);
                    txtAddress1.Text = myCust.Address1;
                    txtCity.Text = myCust.City;
                    txtPostal.Text = myCust.MailCode;
                    txtRegion.Text = myCust.Region;
                    txtPassword.Text = myCust.Password;

                    int srchCtr = 0;

                    foreach (ListItem srchItem in drpDwnCountry.Items)
                    {
                        if (srchItem.Text == myCust.Country)
                            drpDwnCountry.SelectedIndex = srchCtr;

                        srchCtr++;
                    }

                    foreach (ListItem srchItem in drpDwnCredit.Items)
                    {
                        if (srchItem.Text == myCust.CreditCardType)
                            drpDwnCredit.SelectedIndex = srchCtr;

                        srchCtr++;
                    }
                    wzrdUpdate.ActiveStepIndex = 0;

                    myCust.Password = txtConfirmPW.Text;
                }
            }
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Problem Loading - " + ex.Message;
        }
    }
    /// <summary>
    /// Handles the FinishButtonClick event of the wzrdUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.WizardNavigationEventArgs"/> instance containing the event data.</param>
    protected void wzrdUpdate_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        try
        {
            Customer myCust = new Customer();
            myCust.CustomerID = Convert.ToInt32(Session["CustomerID"]);
            myCust.Username = txtUsername.Text;
            myCust.FirstName = txtFirstName.Text;
            myCust.LastName = txtLastName.Text;
            myCust.Email = txtEmail.Text;
            myCust.Age = Convert.ToInt32(txtAge.Text);
            myCust.Address1 = txtAddress1.Text;
            myCust.City = txtCity.Text;
            myCust.MailCode = txtPostal.Text;
            myCust.Region = txtRegion.Text;
            myCust.Password = txtPassword.Text;
            myCust.CreditCardType = drpDwnCredit.Text;
            myCust.Country = drpDwnCountry.Text;

            if (myCust.UpdateCurrentProfile() > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "User " + txtUsername.Text + " updated!";
                wzrdUpdate.ActiveStepIndex = 0;
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Update Failed - Check Data";
            }
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Problem Updating - " + ex.Message;
        }
    }
}
