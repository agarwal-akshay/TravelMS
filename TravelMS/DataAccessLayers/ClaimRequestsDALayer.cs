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

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO CLAIM_REQUESTS ([Travel_Request_ID],[Claim_Amount],[Settled_Amount],[Emp_Remarks]) VALUES (@Travel_Request_ID,@Claim_Amount,@Settled_Amount,@Remarks)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", claimData.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Claim_Amount", claimData.Claim_Amount);
            insertCmmnd.Parameters.AddWithValue("@Settled_Amount", 0);
            insertCmmnd.Parameters.AddWithValue("@Remarks", claimData.Remarks);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static IDataReader populateTravelRequests(string currUserID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");
            SqlCommand queryCmmnd = new SqlCommand("SELECT Travel_Request_ID FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @User_ID)");

            queryCmmnd.CommandType = CommandType.Text;
            queryCmmnd.Parameters.AddWithValue("@User_ID", currUserID);

            return travelMSysDB.ExecuteReader(queryCmmnd);
        }

        public static string nextClaimID()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand selectCmmnd = new SqlCommand("SELECT IDENT_CURRENT('CLAIM_REQUESTS')+1");
            selectCmmnd.CommandType = CommandType.Text;

            object num = travelMSysDB.ExecuteScalar(selectCmmnd);

            string res;
            if (!(num == null))
            {
                res = ("000000" + num.ToString());
                res = 'C' + res.Substring(res.Length - 6);
                return res;
            }
            throw new Exception("Next Claim Request Failed.");
        }

        public static IDataReader ViewClaimRequests()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand reqListCmmnd = new SqlCommand("SELECT [Claim_ID],[Travel_Request_ID],[Claim_Amount],[Settled_Amount],[Emp_Remarks],[Admin_Remarks],[Claim_Status],[Admin_ID] FROM CLAIM_REQUESTS WHERE Travel_Request_ID IN (SELECT Travel_Request_ID FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @CurUser_ID))");

            reqListCmmnd.Parameters.AddWithValue("@CurUser_ID", WebSecurity.CurrentUserName);

            return travelMSysDB.ExecuteReader(reqListCmmnd);
        }
    }
}