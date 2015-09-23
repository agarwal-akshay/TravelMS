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

        public static List<Models.NewTravelRequestModel> GetAgentRequestList()
        {
            List<Models.NewTravelRequestModel> reqList = TravelDALayer.GetAgentRequestList();
            return reqList;
        }

        public static List<Models.NewTravelRequestModel> GetApproveRejRequestList()
        {
            List<Models.NewTravelRequestModel> reqList = TravelDALayer.GetApproveRejRequestList();
            return reqList;
        }


        public static bool ApproveRejBiz(string TReq_ID, char AorRej)
        {
            if (TravelDALayer.ApproveRejDAL(TReq_ID, AorRej))
                return true;
            return false;
        }
    }
}