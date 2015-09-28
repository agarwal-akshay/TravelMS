using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMS.Models;

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

        public static List<NewTravelRequestModel> GetRequestList()
        {
            var rList = new List<NewTravelRequestModel>();

            var nReader = TravelDALayer.GetRequestList();

            /*Object[] values = new Object[16];
            nReader.GetValues(values);*/

            while (nReader.Read())
            {
                //rList.Add(nReader.Get );
                rList.Add(new NewTravelRequestModel
                {
                    Travel_Request_ID = (string)nReader[0],
                    Emp_ID = Int32.Parse((string)nReader[1]),
                    Trip_Name = (string)nReader[2],
                    Travel_Type_Purpose = (string)nReader[3],
                    Travel_Date = (DateTime)nReader[4],
                    Mode_of_Travel = (string)nReader[5],
                    Travel_Class = (string)nReader[6],
                    Source_City = (string)nReader[7],
                    Destination_City = (string)nReader[8],
                    Travel_Time_hh = (int)nReader[9],
                    Travel_Time_mm = (int)nReader[10],
                    First_Level_Approver = (string)nReader[11],
                    Agent_ID = (string)nReader[12],
                    Request_Status = StatusDetail.TravelRequestStatus((string)nReader[13]),
                    Acco_Status = StatusDetail.AccoStatus((string)nReader[14]),
                    Remarks = (string)nReader[15]
                });
            }

            nReader.Close();
            return rList;
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

        public static bool cancelRequest(string travelRequestID)
        {
            return TravelDALayer.cancelRequest(travelRequestID);
        }

    }
}