using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace eStoreDataObjects
{
    public class CustomerData : eStoreConfig
    {
        // Login procedure
        /// <summary>
        /// Logins the specified HSH customer.
        /// </summary>
        /// <param name="hshCustomer">The HSH customer.</param>
        /// <returns></returns>
        public int Login(Hashtable hshCustomer)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            int iCustomerID = -1;

            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pLoginCustomer";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@username", hshCustomer["username"]);
                cmdCust.Parameters.AddWithValue("@password", hshCustomer["password"]);
                cmdCust.Parameters.Add("@cid", System.Data.SqlDbType.Int).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                iCustomerID = (int)cmdCust.Parameters["@cid"].Value;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CustomerData", "Login");
                iCustomerID = -1;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
                cn.Dispose();
                cmdCust.Dispose();
            }
            return iCustomerID;
        }

        //  Register
        //  parameters serialized in Hashtable
        //  -1 return if register fails, new customerif if successful
        /// <summary>
        /// Registers the specified HSH cust.
        /// </summary>
        /// <param name="hshCust">The HSH cust.</param>
        /// <returns></returns>
        public int Register(Hashtable hshCust)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            int iCustomerID = -1;
            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pCreateCustomer";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@username", hshCust["username"]);
                cmdCust.Parameters.AddWithValue("@firstname", hshCust["firstname"]);
                cmdCust.Parameters.AddWithValue("@lastname", hshCust["lastname"]);
                cmdCust.Parameters.AddWithValue("@email", hshCust["email"]);
                cmdCust.Parameters.AddWithValue("@age", hshCust["age"]);
                cmdCust.Parameters.AddWithValue("@address1", hshCust["address1"]);
                cmdCust.Parameters.AddWithValue("@city", hshCust["city"]);
                cmdCust.Parameters.AddWithValue("@mailcode", hshCust["mailcode"]);
                cmdCust.Parameters.AddWithValue("@region", hshCust["region"]);
                cmdCust.Parameters.AddWithValue("@country", hshCust["country"]);
                cmdCust.Parameters.AddWithValue("@creditcardtype", hshCust["creditcardtype"]);
                cmdCust.Parameters.AddWithValue("@password", hshCust["password"]);
                cmdCust.Parameters.Add("@cid", System.Data.SqlDbType.Int).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                iCustomerID = (int)cmdCust.Parameters["@cid"].Value;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CustomerData", "Register");
                iCustomerID = -1;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
                cn.Dispose();
                cmdCust.Dispose();
            }
            return iCustomerID;
        }

        //  GetNames
        //  parameters serialized in Hashtable
        //  -1 return if register fails, new customerif if successful
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public Hashtable GetNames(int cid)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            Hashtable hshCust = new Hashtable();
            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pGetCustomerNames";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@cid", cid);
                cmdCust.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                hshCust["firstname"] = cmdCust.Parameters["@firstname"].Value;
                hshCust["lastname"] = cmdCust.Parameters["@lastname"].Value;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CustomerData", "GetNames");
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
                cn.Dispose();
                cmdCust.Dispose();
            }
            return hshCust;
        }

        //  Get Current Profile
        //  parameters serialized in Hashtable
        //  -1 return if register fails, new customerif if successful
        /// <summary>
        /// Gets the current profile.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public Hashtable GetCurrentProfile(int cid)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            Hashtable hshCust = new Hashtable();
            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pGetCustomer";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@cid", cid);
                cmdCust.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@age", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@country", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@address1", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@creditcardtype", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@city", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@region", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@mailcode", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cmdCust.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 25).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                hshCust["firstname"] = cmdCust.Parameters["@firstname"].Value;
                hshCust["lastname"] = cmdCust.Parameters["@lastname"].Value;
                hshCust["username"] = cmdCust.Parameters["@username"].Value;
                hshCust["age"] = cmdCust.Parameters["@age"].Value;
                hshCust["country"] = cmdCust.Parameters["@country"].Value;
                hshCust["creditcardtype"] = cmdCust.Parameters["@creditcardtype"].Value;
                hshCust["address1"] = cmdCust.Parameters["@address1"].Value;
                hshCust["city"] = cmdCust.Parameters["@city"].Value;
                hshCust["region"] = cmdCust.Parameters["@region"].Value;
                hshCust["mailcode"] = cmdCust.Parameters["@mailcode"].Value;
                hshCust["email"] = cmdCust.Parameters["@email"].Value;
                hshCust["password"] = cmdCust.Parameters["@password"].Value;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CustomerData", "GetCurrentProfile");
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
                cn.Dispose();
                cmdCust.Dispose();
            }
            return hshCust;
        }

        //  UpdateCurrentProfile
        //  parameters serialized in Hashtable
        //  -1 return if register fails, new customerif if successful
        /// <summary>
        /// Updates the current profile.
        /// </summary>
        /// <param name="hshCust">The HSH cust.</param>
        /// <returns></returns>
        public int UpdateCurrentProfile(Hashtable hshCust)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            int result = -1;
            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pUpdateCustomer";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@cid", hshCust["cid"]);
                cmdCust.Parameters.AddWithValue("@username", hshCust["username"]);
                cmdCust.Parameters.AddWithValue("@firstname", hshCust["firstname"]);
                cmdCust.Parameters.AddWithValue("@lastname", hshCust["lastname"]);
                cmdCust.Parameters.AddWithValue("@email", hshCust["email"]);
                cmdCust.Parameters.AddWithValue("@age", hshCust["age"]);
                cmdCust.Parameters.AddWithValue("@address1", hshCust["address1"]);
                cmdCust.Parameters.AddWithValue("@city", hshCust["city"]);
                cmdCust.Parameters.AddWithValue("@mailcode", hshCust["mailcode"]);
                cmdCust.Parameters.AddWithValue("@region", hshCust["region"]);
                cmdCust.Parameters.AddWithValue("@country", hshCust["country"]);
                cmdCust.Parameters.AddWithValue("@creditcardtype", hshCust["creditcardtype"]);
                cmdCust.Parameters.AddWithValue("@password", hshCust["password"]);
                cmdCust.Parameters.Add("@result", System.Data.SqlDbType.Int).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                result = Convert.ToInt32(cmdCust.Parameters["@result"].Value);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CustomerData", "UpdateCurrentProfile");
                result = -1;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
                cn.Dispose();
                cmdCust.Dispose();
            }
            return result;
        }
    }
}
