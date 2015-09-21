using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class TravelBizLayer
    {
        public static bool TravelReqBiz(Models.NewTravelRequestModel userData)
        {
            if (TravelDALayer.TravelReqDAL(userData))
                return true;
            return false;
        }

        public static List<Models.NewTravelRequestModel> GetRequestList()
        {
            List<Models.NewTravelRequestModel> reqList=TravelDALayer.GetRequestList();
            return reqList;
        }
    }
}