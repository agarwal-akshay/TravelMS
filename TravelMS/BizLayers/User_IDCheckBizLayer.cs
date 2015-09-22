using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace TravelMS
{
    public class User_IDCheckBizLayer
    {
        public static bool User_IDCheckBiz(string requestedUser_ID)
        {
            if (string.IsNullOrWhiteSpace(requestedUser_ID))
                return false;
            var resReader = User_IDCheckDALayer.User_IDCheckDAL(requestedUser_ID);
            if (resReader.Read())
            {
                Console.WriteLine(resReader.GetString(0));
                return false;
            }
            return true;
        }
    }
}