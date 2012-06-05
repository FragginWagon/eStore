using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace eStoreDataObjects
{
    public class ProductData : eStoreConfig
    {
        /// <summary>
        /// Gets the prod info for catalogue.
        /// </summary>
        /// <returns></returns>
        public DataSet GetProdInfoForCatalogue()
        {
            // Create Instance of connection and command object
            SqlConnection conn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("pGetProdInfoForCatalogue", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                int numOfRows = da.Fill(ds, "products"); // creates a disconnected instance
                conn.Close();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ProductData", "GetProdInfoForCatalogue");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public DataSet GetProducts()
        {
            // Create Instance of connection and command object
            SqlConnection conn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("pGetProducts", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                int numOfRows = da.Fill(ds, "products"); // creates a disconnected instance
                conn.Close();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ProductData", "GetProducts");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
            }
            return ds;
        }

        //  UpdateCurrentProfile
        //  parameters serialized in Hashtable
        //  -1 return if register fails, new customerif if successful
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="hshProd">The HSH prod.</param>
        /// <returns></returns>
        public bool UpdateProduct(Hashtable hshProd)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdCust = new SqlCommand();
            bool result = false;
            try
            {
                cmdCust.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCust.CommandText = "pUpdateProduct";
                cmdCust.Connection = cn;
                cmdCust.Parameters.AddWithValue("@prodcd", hshProd["prodcd"]);
                cmdCust.Parameters.AddWithValue("@prodnam", hshProd["prodnam"]);
                cmdCust.Parameters.AddWithValue("@graphic", hshProd["graphic"]);
                cmdCust.Parameters.AddWithValue("@cost", hshProd["cost"]);
                cmdCust.Parameters.AddWithValue("@msrp", hshProd["msrp"]);
                cmdCust.Parameters.AddWithValue("@qoh", hshProd["qoh"]);
                cmdCust.Parameters.AddWithValue("@qob", hshProd["qob"]);
                cmdCust.Parameters.Add("@result", System.Data.SqlDbType.Int).Direction =
                    System.Data.ParameterDirection.Output;
                cn.Open();
                cmdCust.ExecuteNonQuery();
                result = Convert.ToBoolean(cmdCust.Parameters["@result"].Value);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductData", "UpdateProduct");
                result = false;
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
