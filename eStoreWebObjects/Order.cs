using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using eStoreDataObjects;

namespace eStoreWebObjects
{
    public class Order : eStoreConfig
    {
        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="cid">The cid.</param>
        /// <param name="amt">The amt.</param>
        /// <param name="shipDate">The ship date.</param>
        /// <returns></returns>
        public Hashtable AddOrder(CartItem[] items, int cid, decimal amt, DateTime shipDate)
        {
            Hashtable retVals = new Hashtable();
            Hashtable hshOrder = new Hashtable();

            try
            {
                OrderData myData = new OrderData();
                int idx = 0;
                string[] prodcds = new string[items.Length];
                int[] qty = new int[items.Length];

                foreach (CartItem item in items)
                {
                    prodcds[idx] = item.ProdCd;
                    qty[idx++] = item.Qty;
                }
                hshOrder["prodcd"] = prodcds;
                hshOrder["qty"] = qty;
                hshOrder["cid"] = cid;
                hshOrder["amt"] = amt;
                hshOrder["shipdate"] = shipDate;

                retVals = myData.AddOrder(hshOrder);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "AddOrder");
                retVals.Add("webmessage", ex.Message);
            }
            return retVals;
        }

        /// <summary>
        /// Gets the order nos and dates.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public DataTable GetOrderNosAndDates(int cid)
        {
            DataSet dsOrders = new DataSet();
            try
            {
                OrderData myData = new OrderData();
                dsOrders = myData.GetOrderNosAndDates(cid);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "GetOrderNosAndDates");
            }
            return dsOrders.Tables["ordernos"];
        }


        /// <summary>
        /// Orders the data details.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="oid">The oid.</param>
        /// <returns></returns>
        public DataTable OrderDataDetails(int cid, int oid)
        {
            DataSet dsOrder = new DataSet();
            try
            {
                OrderData myData = new OrderData();
                dsOrder = myData.OrderDataDetails(cid, oid);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "OrderData");
            }
            return dsOrder.Tables["orderdeets"];
        }

        /// <summary>
        /// Gets all order details.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public DataSet GetAllOrderDetails(int cid)
        {
            DataSet dsOrder = new DataSet();
            try
            {
                OrderData myData = new OrderData();
                dsOrder = myData.GetAllOrderDetails(cid);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "OrderData");
            }
            return dsOrder;
        }
    }
}
