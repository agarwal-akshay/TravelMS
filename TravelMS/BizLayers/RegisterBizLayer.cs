using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class RegisterBizLayer
    {
        public static bool RegisterUserBiz(Models.RegisterModel userData)
        {
            if (RegisterDALayer.RegisterUserDAL(userData))
                return true;
            return false;
        }
    }
}