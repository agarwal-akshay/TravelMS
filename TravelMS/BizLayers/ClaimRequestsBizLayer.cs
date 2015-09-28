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

        public static IEnumerable<SelectListItem> populateTravelRequests(string currUserID)
        {
            var lstObj = new List<SelectListItem>();
            var dr = ClaimRequestsDALayer.populateTravelRequests(currUserID);
            while (dr.Read())
            {
                lstObj.Add(new SelectListItem { Text = dr.GetString(dr.GetOrdinal("Travel_Request_ID")),
                Value = dr.GetString(dr.GetOrdinal("Travel_Request_ID"))
                });
            }
            dr.Close();
            return lstObj;
        }

        public static string nextClaimID()
        {
            return ClaimRequestsDALayer.nextClaimID();
        }

        public static IEnumerable<ClaimRequestsModel> ViewClaimRequests()
        {
            var dr = ClaimRequestsDALayer.ViewClaimRequests();
            var rList = new List<ClaimRequestsModel>();
            while (dr.Read())
            {
                System.Diagnostics.Debug.WriteLine(rList);
                rList.Add(new ClaimRequestsModel
                {
                    Claim_ID = (string)(dr[0]),
                    Travel_Request_ID = dr.GetString(1),
                    Claim_Amount = dr.GetInt32(2),
                    Settled_Amount = dr.GetInt32(3),
                    Remarks = dr.GetString(4),
                    Admin_Remarks = dr.GetString(5),
                    Claim_Status = dr.GetString(6),
                    Admin_ID = dr.GetString(7)
                });
            }
            dr.Close();
            return rList;
        }

        public static IEnumerable<ClaimRequestsModel> SettleClaimRequests()
        {
            var dr = ClaimRequestsDALayer.SettleClaimRequests();
            var rList = new List<ClaimRequestsModel>();
            while (dr.Read())
            {
                System.Diagnostics.Debug.WriteLine(rList);
                rList.Add(new ClaimRequestsModel
                {
                    Claim_ID = (string)(dr[0]),
                    Travel_Request_ID = dr.GetString(1),
                    Claim_Amount = dr.GetInt32(2),
                    Settled_Amount = dr.GetInt32(3),
                    Remarks = dr.GetString(4),
                    Admin_Remarks = dr.GetString(5),
                    Claim_Status = dr.GetString(6),
                    Admin_ID = dr.GetString(7)
                });
            }
            dr.Close();
            return rList;
        }

        public static void SettleClaim(string p,int a ,string b)
        {
            ClaimRequestsDALayer.SettleClaim(p,a,b);
        }
    }
}