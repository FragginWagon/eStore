using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace eStoreDataObjects
{
    public class eStoreConfig
    {
        // Connection string to the e-store database
        /// <summary>
        /// Conns the string.
        /// </summary>
        /// <returns></returns>
        public static string ConnString()
        {
            return "integrated security=sspi;initial catalog=eStoreDB;data source=GREGJ\\GREGJ";
        }

        // error routine to output to the error log
        /// <summary>
        /// Errors the routine.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="method">The method.</param>
        public static void ErrorRoutine(Exception e, string obj, string method)
        {
            // create log and source with LogCreator app before using this method
            EventLog log = new EventLog();
            log.Source = "INFO-3067 Exercises";
            log.Log = "INFO3067";
            log.WriteEntry("Error in exerciseDataObjects, object=" + obj +
                ", method=" + method + ", message=" +
                e.Message, EventLogEntryType.Error);
            throw e;
        }
    }
}
