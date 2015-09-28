using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMS.Models;
using WebMatrix.WebData;

namespace TravelMS
{
    public class AccoDALayer
    {
        public static bool addAccoDetails(AccoModel accoData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO ACCOMMODATION_DETAILS ([Travel_Request_ID],[City],[Check_in_Date],[Check_out_Date],[Room_Type]) VALUES (@Travel_Request_ID,@City,@Check_in_Date,@Check_out_Date,@Room_Type)");
            insertCmmnd.CommandType = CommandType.Text;


            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", accoData.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@City", accoData.City);
            insertCmmnd.Parameters.AddWithValue("@Check_in_Date", accoData.Check_in_Date);
            insertCmmnd.Parameters.AddWithValue("@Check_out_Date", accoData.Check_out_Date);
            insertCmmnd.Parameters.AddWithValue("@Room_Type", accoData.Room_Type);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);

            SqlCommand updateCmmnd = new SqlCommand("UPDATE TRAVEL_REQUESTS SET Acco_Status = 'Y' WHERE Travel_Request_ID = @Travel_Request_ID");
            updateCmmnd.CommandType = CommandType.Text;

            updateCmmnd.Parameters.AddWithValue("@Travel_Request_ID", accoData.Travel_Request_ID);

            travelMSysDB.ExecuteNonQuery(updateCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static List<string> getLastRequest()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand selectCmmnd = new SqlCommand("SELECT Travel_Request_ID, Destination_City FROM TRAVEL_REQUESTS WHERE INCR = (SELECT IDENT_CURRENT('TRAVEL_REQUESTS'))");
            selectCmmnd.CommandType = CommandType.Text;

            var dr = travelMSysDB.ExecuteReader(selectCmmnd);

            var res = new List<string>();
            if (dr.Read())
            {
                res.Add("000000" + (string)dr[0]);
                res[0] = "R" + res[0].Substring(res[0].Length-6);
                res.Add((string)dr[1]);
                return res;
            }
            throw new Exception("Error in obtaining last travel request.");
        }
    }
}