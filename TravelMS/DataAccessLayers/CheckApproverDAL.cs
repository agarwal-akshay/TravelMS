using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class CheckApproverDAL
    {
        public static bool ApproverIsFirstLevel(string appr)
        {
            if (string.IsNullOrWhiteSpace(appr))
                return false;
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand queryCmmnd = new SqlCommand("SELECT Job_Level FROM EMPLOYEES WHERE User_ID=@User_ID");
            queryCmmnd.CommandType = CommandType.Text;

            queryCmmnd.Parameters.AddWithValue("@User_ID", appr);

            object level = travelMSysDB.ExecuteScalar(queryCmmnd);
            if (level == null)
                return false;

            if (level.ToString().Equals("1"))
                return true;

            return false;
        }
    }
}