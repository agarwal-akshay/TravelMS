using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMS.Models;

namespace TravelMS
{
    public class AccoBizLayer
    {
        public static bool addAccoDetails(AccoModel acco)
        {
            return AccoDALayer.addAccoDetails(acco);
        }

        public static List<string> getLastRequest()
        {
            return AccoDALayer.getLastRequest();
        }
    }
}