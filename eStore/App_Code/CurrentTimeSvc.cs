using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for CurrentTimeSvc
/// </summary>
[WebService(Namespace = "http://eStoreCase2/CurrentTimeSvc/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CurrentTimeSvc : System.Web.Services.WebService
{

    public CurrentTimeSvc()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld(string name)
    {
        return "Hello " + name + " the current time on this server is " + Convert.ToString(System.DateTime.Now.TimeOfDay);
    }

}

