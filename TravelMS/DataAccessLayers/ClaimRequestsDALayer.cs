using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TravelMS.Models;
using WebMatrix.WebData;

namespace TravelMS
{
    public class ClaimRequestsDALayer
    {
        public static bool NewClaimRequest(ClaimRequestsModel claimData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO CLAIM_REQUESTS ([Travel_Request_ID],[Claim_Request_ID],[Claim_Amount],[Remarks] VALUES (@Travel_Request_ID,@Claim_Request_ID,@Claim_Amount,@Remarks)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", claimData.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Claim_Request_ID", claimData.Claim_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Claim_Amount", claimData.Claim_Amount);
            insertCmmnd.Parameters.AddWithValue("@Remarks", claimData.Remarks);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        //public static List<Models.NewTravelRequestModel> GetRequestList()
        //{
        //    SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

        //    SqlCommand reqListCmmnd = new SqlCommand("SELECT * FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @CurUser_ID)");

        //    reqListCmmnd.Parameters.AddWithValue("@CurUser_ID", WebSecurity.CurrentUserName);

        //    IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

        //    List<Models.NewTravelRequestModel> rList = new List<Models.NewTravelRequestModel>();

        //    /*Object[] values = new Object[16];
        //    nReader.GetValues(values);*/

        //    while (nReader.Read())
        //    {
        //        //rList.Add(nReader.Get );
        //        rList.Add(new Models.NewTravelRequestModel
        //        {
        //            Travel_Request_ID = (string)nReader[0],
        //            Emp_ID = Int32.Parse((string)nReader[1]),
        //            Trip_Name = (string)nReader[2],
        //            Travel_Type_Purpose = (string)nReader[3],
        //            Travel_Date = (DateTime)nReader[4],
        //            Mode_of_Travel = (string)nReader[5],
        //            Travel_Class = (string)nReader[6],
        //            Source_City = (string)nReader[7],
        //            Destination_City = (string)nReader[8],
        //            Travel_Time_hh = (int)nReader[9],
        //            Travel_Time_mm = (int)nReader[10],
        //            First_Level_Approver = (string)nReader[11],
        //            Agent_ID = (string)nReader[12],
        //            Request_Status = (string)nReader[13],
        //            Acco_Status = (string)nReader[14],
        //            Remarks = (string)nReader[15]
        //        });
        //    }

        //    nReader.Close();
        //    return rList;
        //}

        public static IDataReader populateTravelRequests(string currUserID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");
            SqlCommand queryCmmnd = new SqlCommand("SELECT Travel_Request_ID FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @User_ID)");

            queryCmmnd.CommandType = CommandType.Text;
            queryCmmnd.Parameters.AddWithValue("@User_ID", currUserID);

            return travelMSysDB.ExecuteReader(queryCmmnd);
        }
    }
}