using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class AgentDALayer
    {
        public static bool BookTicketDAL(Models.TicketBooking data)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO TICKET_BOOKINGS ([Travel_Request_ID],[Ticket_Details],[Booking_Status]) VALUES (@Travel_Request_ID,@Ticket_Details,@Booking_Status)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", data.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Ticket_Details", data.Ticket_Details);
            insertCmmnd.Parameters.AddWithValue("@Booking_Status", data.Booking_Status);
            
            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);

            SqlCommand updateCmmnd = new SqlCommand("UPDATE TRAVEL_REQUESTS SET [Request_Status]='P' WHERE Travel_Request_ID=@Travel_Request_ID");
            updateCmmnd.CommandType = CommandType.Text;

            updateCmmnd.Parameters.AddWithValue("@Travel_Request_ID", data.Travel_Request_ID);

            int rowsAffectedTReq = travelMSysDB.ExecuteNonQuery(updateCmmnd);

            //two booking records for same travel req issue to be resolved wherever applicable - or just delete the rows when booking cancelled
            if (rowsAffected == 1&&rowsAffectedTReq==1)
                return true;
            return false;
        }
    }
}