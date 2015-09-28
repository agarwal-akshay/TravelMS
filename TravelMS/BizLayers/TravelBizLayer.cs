using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static string TravelUserEmp_IDBiz(string User_ID)
        {
            return TravelDALayer.GetUserEmp_ID(User_ID);
        }

        public static string TravelNextReq_IDBiz()
        {
            return TravelDALayer.GetNextReq_IDBiz();
        }

        public static IEnumerable<SelectListItem> AgentListBiz()
        {
            return TravelDALayer.AgentListDAL();
        }

        public static List<Models.TicketBooking> GetAgentBookedList()
        {
            List<Models.TicketBooking> reqList = TravelDALayer.GetAgentBookedList();
            return reqList;
        }

        public static void CancelTicket(string p)
        {
            TravelDALayer.CancelTicket(p);
        }

        public static void ChangeTravelReq(Models.NewTravelRequestModel data)
        {
            TravelDALayer.ChangeTravelReq(data);
        }
    }
}