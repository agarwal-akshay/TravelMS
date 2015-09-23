using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class CheckApproverBiz
    {
        public static bool ApproverIsFirstLevel(string appr)
        {
            if(CheckApproverDAL.ApproverIsFirstLevel(appr))
                return true;
            return false;
        }
    }
}