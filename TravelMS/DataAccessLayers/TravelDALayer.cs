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
    public class TravelDALayer
    {
        public static bool TravelReqDAL(NewTravelRequestModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO TRAVEL_REQUESTS ([Emp_ID],[Trip_Name],[Travel_Type_Purpose],[Travel_Date],[Mode_of_Travel],[Travel_Class],[Source_City],[Destination_City],[Travel_Time_hh],[Travel_Time_mm],[First_Level_Approver],[Agent_ID],[Remarks]) VALUES (@Emp_ID,@Trip_Name,@Travel_Type_Purpose,@Travel_Date,@Mode_of_Travel,@Travel_Class,@Source_City,@Destination_City,@Travel_Time_hh,@Travel_Time_mm,@First_Level_Approver,@Agent_ID,@Remarks)");
            insertCmmnd.CommandType = CommandType.Text;

            
            insertCmmnd.Parameters.AddWithValue("@Emp_ID", userData.Emp_ID);
            insertCmmnd.Parameters.AddWithValue("@Trip_Name", userData.Trip_Name);
            insertCmmnd.Parameters.AddWithValue("@Travel_Type_Purpose", userData.Travel_Type_Purpose);
            insertCmmnd.Parameters.AddWithValue("@Travel_Date", userData.Travel_Date);
            insertCmmnd.Parameters.AddWithValue("@Mode_of_Travel", userData.Mode_of_Travel);
            insertCmmnd.Parameters.AddWithValue("@Travel_Class", userData.Travel_Class);
            insertCmmnd.Parameters.AddWithValue("@Source_City", userData.Source_City);
            insertCmmnd.Parameters.AddWithValue("@Destination_City", userData.Destination_City);
            insertCmmnd.Parameters.AddWithValue("@Travel_Time_hh", userData.Travel_Time_hh);
            insertCmmnd.Parameters.AddWithValue("@Travel_Time_mm", userData.Travel_Time_mm);
            insertCmmnd.Parameters.AddWithValue("@First_Level_Approver", userData.First_Level_Approver);
            insertCmmnd.Parameters.AddWithValue("@Agent_ID", userData.Agent_ID);
            insertCmmnd.Parameters.AddWithValue("@Remarks", userData.Remarks);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static List<NewTravelRequestModel> GetRequestList()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand reqListCmmnd = new SqlCommand("SELECT [Travel_Request_ID],[Emp_ID],[Trip_Name],[Travel_Type_Purpose],[Travel_Date],[Mode_of_Travel],[Travel_Class],[Source_City],[Destination_City],[Travel_Time_hh],[Travel_Time_mm],[First_Level_Approver],[Agent_ID],[Request_Status],[Acco_Status],[Remarks] FROM TRAVEL_REQUESTS WHERE Emp_ID = (SELECT Emp_ID FROM EMPLOYEES WHERE User_ID = @CurUser_ID)");

            reqListCmmnd.Parameters.AddWithValue("@CurUser_ID", WebSecurity.CurrentUserName);

            IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

            var rList = new List<Models.NewTravelRequestModel>();

            /*Object[] values = new Object[16];
            nReader.GetValues(values);*/

            while (nReader.Read())
            {
                //rList.Add(nReader.Get );
                rList.Add(new Models.NewTravelRequestModel
                {
                    Travel_Request_ID = (string)nReader[0],
                    Emp_ID = Int32.Parse((string)nReader[1]),
                    Trip_Name = (string)nReader[2],
                    Travel_Type_Purpose = (string)nReader[3],
                    Travel_Date=(DateTime)nReader[4],
                    Mode_of_Travel=(string)nReader[5],
                    Travel_Class=(string)nReader[6],
                    Source_City=(string)nReader[7],
                    Destination_City=(string)nReader[8],
                    Travel_Time_hh=(int)nReader[9],
                    Travel_Time_mm=(int)nReader[10],
                    First_Level_Approver=(string)nReader[11],
                    Agent_ID=(string)nReader[12],
                    Request_Status=StatusDetail.TravelRequestStatus( (string)nReader[13]),
                    Acco_Status=StatusDetail.AccoStatus((string)nReader[14]),
                    Remarks=(string)nReader[15]
                });
            }

            nReader.Close();
            return rList;
        }

        public static List<NewTravelRequestModel> GetAgentRequestList()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand reqListCmmnd = new SqlCommand("SELECT [Travel_Request_ID],[Emp_ID],[Trip_Name],[Travel_Type_Purpose],[Travel_Date],[Mode_of_Travel],[Travel_Class],[Source_City],[Destination_City],[Travel_Time_hh],[Travel_Time_mm],[First_Level_Approver],[Agent_ID],[Request_Status],[Acco_Status],[Remarks] FROM TRAVEL_REQUESTS  WHERE Agent_ID = @CurAgent_ID AND REQUEST_STATUS='A' OR REQUEST_STATUS='P'");

            reqListCmmnd.Parameters.AddWithValue("@CurAgent_ID", WebSecurity.CurrentUserName);

            IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

            List<Models.NewTravelRequestModel> rList = new List<Models.NewTravelRequestModel>();

            /*Object[] values = new Object[16];
            nReader.GetValues(values);*/

            while (nReader.Read())
            {
                //rList.Add(nReader.Get );
                rList.Add(new Models.NewTravelRequestModel
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
                    Acco_Status =StatusDetail.AccoStatus( (string)nReader[14]),
                    Remarks = (string)nReader[15]
                });
            }

            nReader.Close();
            return rList;
        }


        public static List<NewTravelRequestModel> GetApproveRejRequestList()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand reqListCmmnd = new SqlCommand("SELECT [Travel_Request_ID],[Emp_ID],[Trip_Name],[Travel_Type_Purpose],[Travel_Date],[Mode_of_Travel],[Travel_Class],[Source_City],[Destination_City],[Travel_Time_hh],[Travel_Time_mm],[First_Level_Approver],[Agent_ID],[Request_Status],[Acco_Status],[Remarks] FROM TRAVEL_REQUESTS  WHERE First_Level_Approver = @CurAgent_ID");

            reqListCmmnd.Parameters.AddWithValue("@CurAgent_ID", WebSecurity.CurrentUserName);

            IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

            List<Models.NewTravelRequestModel> rList = new List<Models.NewTravelRequestModel>();

            /*Object[] values = new Object[16];
            nReader.GetValues(values);*/

            while (nReader.Read())
            {
                //rList.Add(nReader.Get );
                rList.Add(new Models.NewTravelRequestModel
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
                    Acco_Status =StatusDetail.AccoStatus( (string)nReader[14]),
                    Remarks = (string)nReader[15]
                });
            }

            nReader.Close();
            return rList;
        }

        public static bool ApproveRejDAL(string TReq_ID, char AorRej)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("UPDATE TRAVEL_REQUESTS SET Request_Status=@AorRej WHERE Travel_Request_ID=@TReq_ID");
            insertCmmnd.CommandType = CommandType.Text;

            string x=AorRej.ToString();
            insertCmmnd.Parameters.AddWithValue("@AorRej",x);
            insertCmmnd.Parameters.AddWithValue("@TReq_ID", TReq_ID);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            //int rowsAffected = travelMSysDB.ExecuteNonQuery(new SqlCommand("UPDATE TRAVEL_REQUESTS SET Request_Status='R' WHERE Travel_Request_ID='R445'"));
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static string GetUserEmp_ID(string User_ID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand selectCmmnd = new SqlCommand("SELECT [Emp_ID] FROM EMPLOYEES WHERE [User_ID]=@User_ID");
            selectCmmnd.CommandType = CommandType.Text;

            selectCmmnd.Parameters.AddWithValue("@User_ID", User_ID);

            object pHash = travelMSysDB.ExecuteScalar(selectCmmnd);

            if (!(pHash == null))
                return pHash.ToString();
            throw new Exception("Emp_ID not found for User_ID=" + User_ID);
        }

        public static string GetNextReq_IDBiz()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand selectCmmnd = new SqlCommand("SELECT IDENT_CURRENT('TRAVEL_REQUESTS')+1");
            selectCmmnd.CommandType = CommandType.Text;

            object num = travelMSysDB.ExecuteScalar(selectCmmnd);

            string res;
            if (!(num == null))
            {
                res = ("000000"+num.ToString());
                res='R'+res.Substring(res.Length-6);
                return res;
            }
            throw new Exception("auto increment row num for TRAVEL_REQUESTS not got");
        }

        //System.Web.Mvc vs. System.Web.WebPages.Html stackoverflow
        public static IEnumerable<SelectListItem> AgentListDAL()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand reqListCmmnd = new SqlCommand("SELECT [Agent_ID],[Agent_Name] FROM AGENTS");

            IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

            List<SelectListItem> rList = new List<SelectListItem>();
            while (nReader.Read())
            {
                rList.Add(new SelectListItem
                {
                    Text = (string)nReader[1],
                    Value=(string)nReader[0]
                });
            }

            nReader.Close();
            return (IEnumerable < SelectListItem > )rList;
        }

        public static List<TicketBooking> GetAgentBookedList()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand reqListCmmnd = new SqlCommand("SELECT t.[Ticket_Booking_ID],t.[Travel_Request_ID],t.[Ticket_Details],t.[Booking_Status] FROM TICKET_BOOKINGS t JOIN TRAVEL_REQUESTS r ON t.Travel_Request_ID=r.Travel_Request_ID AND r.Agent_ID = @CurAgent_ID AND t.Booking_Status='B'");

            reqListCmmnd.Parameters.AddWithValue("@CurAgent_ID", WebSecurity.CurrentUserName);

            IDataReader nReader = travelMSysDB.ExecuteReader(reqListCmmnd);

            List<Models.TicketBooking> rList = new List<Models.TicketBooking>();

            /*Object[] values = new Object[16];
            nReader.GetValues(values);*/

            while (nReader.Read())
            {
                //rList.Add(nReader.Get );
                rList.Add(new Models.TicketBooking
                {
                    Travel_Request_ID = (string)nReader[1],
                    Ticket_Booking_ID = ((string)nReader[0]),
                    Ticket_Details = (string)nReader[2],
                    Booking_Status = StatusDetail.BookingStatus((string)nReader[3])
                });
            }

            nReader.Close();
            return rList;
        }


        public static void CancelTicket(string Ticket_Booking_ID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("DELETE FROM TICKET_BOOKINGS WHERE Ticket_Booking_ID=@Ticket_Booking_ID");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Ticket_Booking_ID", Ticket_Booking_ID);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            //int rowsAffected = travelMSysDB.ExecuteNonQuery(new SqlCommand("UPDATE TRAVEL_REQUESTS SET Request_Status='R' WHERE Travel_Request_ID='R445'"));
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                ;
            else
                throw new Exception("Ticket cancel: Data access process error");
        }

        public static void ChangeTravelReq(NewTravelRequestModel data)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand updCmmnd = new SqlCommand("UPDATE TRAVEL_REQUESTS SET Trip_Name=@Trip_Name,Travel_Type_Purpose=@Travel_Type_Purpose,Travel_Date=@Travel_Date,Mode_of_Travel=@Mode_of_Travel,Travel_Class=@Travel_Class,Source_City=@Source_City,Destination_City=@Destination_City,Travel_Time_hh=@Travel_Time_hh,Travel_Time_mm=@Travel_Time_mm,First_Level_Approver=@First_Level_Approver,Agent_ID=@Agent_ID,Remarks=@Remarks WHERE Travel_Request_ID=@Travel_Request_ID");
            updCmmnd.CommandType = CommandType.Text;

            updCmmnd.Parameters.AddWithValue("@Travel_Request_ID", data.Travel_Request_ID);
            updCmmnd.Parameters.AddWithValue("@Trip_Name", data.Trip_Name);
            updCmmnd.Parameters.AddWithValue("@Travel_Type_Purpose", data.Travel_Type_Purpose);
            updCmmnd.Parameters.AddWithValue("@Travel_Date", data.Travel_Date);
            updCmmnd.Parameters.AddWithValue("@Mode_of_Travel", data.Mode_of_Travel);
            updCmmnd.Parameters.AddWithValue("@Travel_Class", data.Travel_Class);
            updCmmnd.Parameters.AddWithValue("@Source_City", data.Source_City);
            updCmmnd.Parameters.AddWithValue("@Destination_City", data.Destination_City);
            updCmmnd.Parameters.AddWithValue("@Travel_Time_hh", data.Travel_Time_hh);
            updCmmnd.Parameters.AddWithValue("@Travel_Time_mm", data.Travel_Time_mm);
            updCmmnd.Parameters.AddWithValue("@First_Level_Approver", data.First_Level_Approver);
            updCmmnd.Parameters.AddWithValue("@Agent_ID", data.Agent_ID);
            updCmmnd.Parameters.AddWithValue("@Remarks", data.Remarks);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(updCmmnd);
            //int rowsAffected = travelMSysDB.ExecuteNonQuery(new SqlCommand("UPDATE TRAVEL_REQUESTS SET Request_Status='R' WHERE Travel_Request_ID='R445'"));
            Console.Write("rowsAffected " + rowsAffected);
            if(rowsAffected!=1)
                throw new Exception("Change Travel Request DAL error");
        }
    }
}