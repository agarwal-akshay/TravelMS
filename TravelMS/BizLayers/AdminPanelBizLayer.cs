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
            var dr = AdminPanelDALayer.lockedAccounts();
            while (dr.Read())
            {
                lstObj.Add(FillDataRecord(dr));
            }
            dr.Close();
            return lstObj;
        }

        public static bool unlockAccount(string requestedUser_ID)
        {
            return AdminPanelDALayer.unlockAccount(requestedUser_ID);
        }

        private static RegisterModel FillDataRecord(IDataReader dr)
        {
            var rm = new RegisterModel();

            rm.Emp_ID = Int32.Parse(dr.GetString(dr.GetOrdinal("Emp_ID")));
            rm.Emp_Name = dr.GetString(dr.GetOrdinal("Emp_Name"));
            rm.User_ID = dr.GetString(dr.GetOrdinal("User_ID"));
            rm.Gender = dr.GetString(dr.GetOrdinal("Gender"));
            rm.Job_Level = dr.GetInt32(dr.GetOrdinal("Job_Level"));
            rm.Job_Location = dr.GetString(dr.GetOrdinal("Job_Location"));
            rm.Access_Status = StatusDetail.AccessStatus(dr.GetString(dr.GetOrdinal("Access_Status")));

            return rm;
        }

        public static bool addAgent(AgentModel model)
        {
            return AdminPanelDALayer.addAgent(model);
        }
    }
}