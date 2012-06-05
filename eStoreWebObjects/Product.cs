using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eStoreDataObjects;
using System.Collections;

namespace eStoreWebObjects
{
    public class Product : eStoreConfig
    {
        /// <summary>
        /// Gets the prod info for catalogue.
        /// </summary>
        /// <returns></returns>
        public DataTable GetProdInfoForCatalogue()
        {
            DataSet mySet = new DataSet();
            try
            {
                ProductData myData = new ProductData();
                mySet = myData.GetProdInfoForCatalogue();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Products", "GetProdInfoForCatalogue");
            }
            return mySet.Tables[0];
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public DataTable GetProducts()
        {
            DataSet mySet = new DataSet();
            try
            {
                ProductData myData = new ProductData();
                mySet = myData.GetProducts();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Products", "GetProducts");
            }
            return mySet.Tables[0];
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="hshProd">The HSH prod.</param>
        /// <returns></returns>
        public bool UpdateProduct(Hashtable hshProd)
        {
            bool result = false;
            try
            {
                ProductData myData = new ProductData();
                result = myData.UpdateProduct(hshProd);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "UpdateProduct");
            }
            return result;
        }
    }
}