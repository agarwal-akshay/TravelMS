using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class ConnString
    {
        public static string DBConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["TravelMSConnString"].ConnectionString;
    }
}