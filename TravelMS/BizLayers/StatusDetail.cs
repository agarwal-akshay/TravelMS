using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class StatusDetail
    {
        public static string AccessStatus(string s)
        {
            if (s.Equals("T"))
                return "Unlocked";
            else if (s.Equals("F"))
                return "Locked";
            return "Invalid status";
        }

        public static string TravelRequestStatus(string s)
        {
            if (s.Equals("A")) return "Approved";
            else if (s.Equals("S")) return "Submitted";
            else if (s.Equals("P")) return "Processed";
            else if (s.Equals("R")) return "Rejected";
            else if (s.Equals("C")) return"Cancelled";

            return "Invalid status";
        }

        public static string BookingStatus(string s)
        {
            if (s.Equals("B"))
                return "Booked";
            else if (s.Equals("N"))
                return "Not Booked";
            return "Invalid status";
        }
        public static string AccoStatus(string s)
        {
            if (s.Equals("Y"))
                return "Yes";
            else if (s.Equals("N"))
                return "No";
            return "Invalid status";
        }
    }
}