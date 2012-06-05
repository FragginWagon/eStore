using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace eStoreWebObjects
{
    public class eStoreConfig
    {
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
            log.WriteEntry("Error in eStoreWebObjects, object=" + obj +
                ", method=" + method + ", message=" +
                e.Message, EventLogEntryType.Error);
            throw e;
        }
    }
}
