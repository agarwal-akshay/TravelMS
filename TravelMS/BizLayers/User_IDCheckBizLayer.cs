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
            if(User_IDCheckDALayer.User_IDCheckDAL(requestedUser_ID))
                return true;
            return false;
        }
    }
}