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
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO TICKET_BOOKINGS ([Travel_Request_ID],[Ticket_Details],[Booking_status]) VALUES (@Travel_Request_ID,@Ticket_Details,@Booking_Status)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", data.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Ticket_Details", data.Ticket_Details);
            insertCmmnd.Parameters.AddWithValue("@Booking_Status", data.Booking_Status);
            
            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }
    }
}