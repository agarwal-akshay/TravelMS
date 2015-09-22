using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class AgentBizLayer
    {
        public static bool BookTicketBiz(Models.TicketBooking data)
        {
            data.Booking_Status = "B";
            if (AgentDALayer.BookTicketDAL(data))
                return true;
            return false;
        }
    }
}