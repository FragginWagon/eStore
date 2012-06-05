using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace eStoreDataObjects
{
    public class OrderData : eStoreConfig
    {
        SqlTransaction trans;

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="hshOrder">The HSH order.</param>
        /// <returns></returns>
        public Hashtable AddOrder (Hashtable hshOrder)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmdOrder = new SqlCommand();

            cmdOrder.CommandType = CommandType.StoredProcedure;
            cmdOrder.CommandText = "pOrderAdd";
            SqlCommand cmdOrderLine = new SqlCommand();
            cmdOrderLine.CommandType = CommandType.StoredProcedure;
            cmdOrderLine.CommandText = "pOrderLineItemAdd";
            Hashtable retVals = new Hashtable();
            int boFlg = 0;

            // Add parameters to SPROC
            cmdOrder.Parameters.AddWithValue("@cid", Convert.ToInt32(hshOrder["cid"]));
            cmdOrder.Parameters.AddWithValue("@amt", Convert.ToDecimal(hshOrder["amt"]));
            cmdOrder.Parameters.AddWithValue("@shipdate", Convert.ToDateTime(hshOrder["shipdate"]));
            cmdOrder.Parameters.Add("@oid", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                cn.Open();
                cmdOrder.Connection = cn;
                cmdOrderLine.Connection = cn;
                trans = cn.BeginTransaction();
                cmdOrder.Transaction = trans;
                cmdOrderLine.Transaction = trans;
                cmdOrder.ExecuteNonQuery();
                // Obtain the orderID using output Param from SPROC
                int orderID = (int)cmdOrder.Parameters["@oid"].Value;

                int[] qty = (int[])hshOrder["qty"];
                string[] prodcd = (string[])hshOrder["prodcd"];

                for (int idx = 0; idx < qty.Length; idx++)
                {
                    if (qty[idx] > 0)
                    {
                        cmdOrderLine.Parameters.AddWithValue("@oid", orderID);
                        cmdOrderLine.Parameters.AddWithValue("@prodcd", prodcd[idx]);
                        cmdOrderLine.Parameters.AddWithValue("@qty", qty[idx]);
                        cmdOrderLine.Parameters.Add("@bo", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmdOrderLine.ExecuteNonQuery();
                        if ((int)cmdOrderLine.Parameters["@bo"].Value == 1)
                            boFlg = 1;
                        cmdOrderLine.Parameters.Clear();
                    }
                }

                retVals.Add("orderid", orderID);
                retVals.Add("boflag", boFlg);
                retVals.Add("message", "");
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                ErrorRoutine(e, "OrderData", "AddOrder");
                retVals.Add("message", "Problem with Order");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cmdOrder.Dispose();
                cmdOrderLine.Dispose();
            }
            return retVals;
        }

        /// <summary>
        /// Gets the order nos and dates.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public DataSet GetOrderNosAndDates(int cid)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("pGetOrderNosAndDates", cn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@cid", cid);

                da.SelectCommand = cmd;
                int numOfRows = da.Fill(ds, "ordernos"); // creates a disconnected dataset
                cn.Close();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "OrderData", "GetOrderNosAndDates");
            }
            return ds;
        }

        /// <summary>
        /// Orders the data details.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="oid">The oid.</param>
        /// <returns></returns>
        public DataSet OrderDataDetails(int cid,int oid)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("pSingleOrderDetails", cn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@oid", oid);

                da.SelectCommand = cmd;
                int numOfRows = da.Fill(ds, "orderdeets"); // creates a disconnected dataset
                cn.Close();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "OrderData", "OrderData");
            }
            return ds;
        }

        /// <summary>
        /// Gets all order details.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public DataSet GetAllOrderDetails(int cid)
        {
            SqlConnection cn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("pAllOrderDetails", cn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@cid", cid);

                da.SelectCommand = cmd;
                int numOfRows = da.Fill(ds, "orderdeets"); // creates a disconnected dataset
                cn.Close();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "OrderData", "OrderData");
            }
            return ds;
        }
    }
}
