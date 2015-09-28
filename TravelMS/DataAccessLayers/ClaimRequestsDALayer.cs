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
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO CLAIM_REQUESTS ([Travel_Request_ID],[Claim_ID],[Claim_Amount],[Emp_Remarks]) VALUES (@Travel_Request_ID,@Claim_Request_ID,@Claim_Amount,@Remarks)");
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

        public static IDataReader populateTravelRequests(string currUserID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);
            SqlCommand queryCmmnd = new SqlCommand("SELECT Travel_Request_ID FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @User_ID)");

            queryCmmnd.CommandType = CommandType.Text;
            queryCmmnd.Parameters.AddWithValue("@User_ID", currUserID);

            return travelMSysDB.ExecuteReader(queryCmmnd);
        }
    }
}