using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreWebObjects;

public partial class Register : System.Web.UI.Page
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
            if (!Page.IsPostBack)
                wzrdRegister.ActiveStepIndex = 0;
        }
        catch (Exception ex)
        {
            String tmp = ex.Message;
            lblStatus.Text = "Problem Registering! - Call Tech Support";
        }
    }
    /// <summary>
    /// Handles the FinishButtonClick event of the Wizard1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.WizardNavigationEventArgs"/> instance containing the event data.</param>
    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        try
        {
            Customer myCustomer = new Customer();
            myCustomer.Username = txtUsername.Text;
            myCustomer.Address1 = txtAddress1.Text;
            myCustomer.City = txtCity.Text;
            myCustomer.Country = drpDwnCountry.SelectedValue;
            myCustomer.CreditCardType = drpDwnCredit.SelectedValue;
            myCustomer.FirstName = txtFirstName.Text;
            myCustomer.LastName = txtLastName.Text;
            myCustomer.Age = Convert.ToInt32(txtAge.Text);
            myCustomer.MailCode = txtPostalCode.Text;
            myCustomer.Region = txtRegion.Text;
            myCustomer.Email = txtEmail.Text;
            myCustomer.Password = txtPassword.Text;
            myCustomer.Register();

            if (myCustomer.CustomerID < 0)
                throw new Exception();
            else
                lblStatus.Text = " Customer " + myCustomer.CustomerID + " Registered!";
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            lblStatus.Text = "Problem Registering, Try Again? " + strEx;
        }
    }
}
