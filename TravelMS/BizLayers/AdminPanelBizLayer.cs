using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using TravelMS.Models;
using System.Data.SqlClient;

namespace TravelMS
{
    public class AdminPanelBizLayer
    {
        public static List<RegisterModel> lockedAccounts()
        {
            List<RegisterModel> lstObj = new List<RegisterModel>();
            SqlDataReader dr = AdminPanelDALayer.lockedAccounts();
            while(dr.Read())
            {
                foreach (DataRow drow in dr.GetSchemaTable().Rows)
                {
                    //lstObj.Add(drow);
                }
            }
            return lstObj;
        }
    }
}