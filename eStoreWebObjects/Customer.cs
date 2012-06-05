using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using eStoreDataObjects;


namespace eStoreWebObjects
{
    public class Customer : eStoreConfig
    {
        // instance variables
        private int _customerid;
        private string _username;
        private string _firstname;
        private string _lastname;
        private int _age;
        private string _email;
        private string _address1;
        private string _city;
        private string _mailcode;
        private string _region;
        private string _country;
        private string _creditcardtype;
        private string _password;

        // properties
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public int CustomerID
        {
            get { return _customerid; }
            set { _customerid = value; }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Gets or sets the mail code.
        /// </summary>
        /// <value>The mail code.</value>
        public string MailCode
        {
            get { return _mailcode; }
            set { _mailcode = value; }
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Gets or sets the type of the credit card.
        /// </summary>
        /// <value>The type of the credit card.</value>
        public string CreditCardType
        {
            get { return _creditcardtype; }
            set { _creditcardtype = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        // method
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password)
        {
            try
            {
                CustomerData custData = new CustomerData();
                Hashtable hshCustomer = new Hashtable();
                hshCustomer["username"] = username.Trim();
                hshCustomer["password"] = password.Trim();
                _customerid = custData.Login(hshCustomer);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Customer", "Login");
            }
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        public void Register()
        {
            Hashtable hshCust = new Hashtable();
            try
            {
                CustomerData myData = new CustomerData();
                hshCust["username"] = _username;
                hshCust["firstname"] = _firstname;
                hshCust["lastname"] = _lastname;
                hshCust["age"] = _age;
                hshCust["address1"] = _address1;
                hshCust["city"] = _city;
                hshCust["mailcode"] = _mailcode;
                hshCust["region"] = _region;
                hshCust["email"] = _email;
                hshCust["country"] = _country;
                hshCust["creditcardtype"] = _creditcardtype;
                hshCust["password"] = _password;
                _customerid = myData.Register(hshCust);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Customer", "Register");
            }
        }

        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <param name="customerID">The customer ID.</param>
        public void GetNames(int customerID)
        {
            Hashtable hshCust = new Hashtable();
            try
            {
                CustomerData myData = new CustomerData();
                
                hshCust = myData.GetNames(customerID);
                _firstname = hshCust["firstname"].ToString();
                _lastname = hshCust["lastname"].ToString();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Customer", "GetNames");
            }
        }

        /// <summary>
        /// Gets the current profile.
        /// </summary>
        /// <param name="customerID">The customer ID.</param>
        public void GetCurrentProfile(int customerID)
        {
            Hashtable hshCust = new Hashtable();
            try
            {
                CustomerData myData = new CustomerData();

                hshCust = myData.GetCurrentProfile(customerID);
                _customerid = customerID;
                _firstname = hshCust["firstname"].ToString();
                _lastname = hshCust["lastname"].ToString();
                _username = hshCust["username"].ToString();
                _age = Convert.ToInt32(hshCust["age"]);
                _creditcardtype = hshCust["creditcardtype"].ToString();
                _country = hshCust["country"].ToString();
                _city = hshCust["city"].ToString();
                _email = hshCust["email"].ToString();
                _region = hshCust["region"].ToString();
                _mailcode = hshCust["mailcode"].ToString();
                _password = hshCust["password"].ToString();
                _address1 = hshCust["address1"].ToString();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Customer", "GetCurrentProfile");
            }
        }

        /// <summary>
        /// Updates the current profile.
        /// </summary>
        /// <returns></returns>
        public int UpdateCurrentProfile()
        {
            Hashtable hshCust = new Hashtable();
            int result = -1;
            try
            {
                CustomerData myData = new CustomerData();
                hshCust["cid"] = _customerid;
                hshCust["username"] = _username;
                hshCust["firstname"] = _firstname;
                hshCust["lastname"] = _lastname;
                hshCust["age"] = _age;
                hshCust["address1"] = _address1;
                hshCust["city"] = _city;
                hshCust["mailcode"] = _mailcode;
                hshCust["region"] = _region;
                hshCust["email"] = _email;
                hshCust["country"] = _country;
                hshCust["creditcardtype"] = _creditcardtype;
                hshCust["password"] = _password;
                result = myData.UpdateCurrentProfile(hshCust);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Customer", "UpdateCurrentProfile");
            }
            return result;
        }
    }
}
