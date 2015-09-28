using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMS.Models;

namespace TravelMS
{
    public class ClaimRequestsBizLayer
    {
        public static bool NewClaimRequest(ClaimRequestsModel claimData)
        {
            if (ClaimRequestsDALayer.NewClaimRequest(claimData))
                return true;
            return false;
        }

        //public static List<Models.NewTravelRequestModel> GetRequestList()
        //{
        //    List<Models.NewTravelRequestModel> reqList=TravelDALayer.GetRequestList();
        //    return reqList;
        //}

        public static IEnumerable<SelectListItem> populateTravelRequests(string currUserID)
        {
            var lstObj = new List<SelectListItem>();
            IDataReader dr = ClaimRequestsDALayer.populateTravelRequests(currUserID);
            while (dr.Read())
            {
                lstObj.Add(new SelectListItem { Text = dr.GetString(dr.GetOrdinal("Travel_Request_ID")),
                Value = dr.GetString(dr.GetOrdinal("Travel_Request_ID"))
                });
            }
            dr.Close();
            return lstObj;
        }
    }
}