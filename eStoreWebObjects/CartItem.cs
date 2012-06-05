using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStoreWebObjects
{
    public class CartItem
    {
        //
        // Instance Variables
        //
        private int _qty;
        private string _prodcd;
        private string _prodname;
        private string _graphic;
        private decimal _msrp;

        //
        // Properties
        //
        /// <summary>
        /// Gets or sets the qty.
        /// </summary>
        /// <value>The qty.</value>
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        /// <summary>
        /// Gets or sets the prod cd.
        /// </summary>
        /// <value>The prod cd.</value>
        public string ProdCd
        {
            get { return _prodcd; }
            set { _prodcd = value; }
        }

        /// <summary>
        /// Gets or sets the name of the prod.
        /// </summary>
        /// <value>The name of the prod.</value>
        public string ProdName
        {
            get { return _prodname; }
            set { _prodname = value; }
        }

        /// <summary>
        /// Gets or sets the graphic.
        /// </summary>
        /// <value>The graphic.</value>
        public string Graphic
        {
            get { return _graphic; }
            set { _graphic = value; }
        }

        /// <summary>
        /// Gets or sets the MSRP.
        /// </summary>
        /// <value>The MSRP.</value>
        public decimal Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }


    }
}
