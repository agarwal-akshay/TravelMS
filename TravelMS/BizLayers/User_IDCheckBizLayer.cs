﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using TravelMS.ServiceReference1;

namespace TravelMS
{
    public class User_IDCheckBizLayer
    {
        public static bool User_IDCheckBiz(string requestedUser_ID)
        {
            if (string.IsNullOrWhiteSpace(requestedUser_ID))
                return false;
            Service1Client proxyObj = new Service1Client();

            var resReader = User_IDCheckDALayer.User_IDCheckDAL(requestedUser_ID);
            if (resReader.Read())
            {
                Console.WriteLine(resReader.GetString(0));
                resReader.Close();
                return false;
            }
            return true;
            //if (proxyObj.CheckUser(requestedUser_ID))
            //    return true;
            //return false;
        }
    }
}