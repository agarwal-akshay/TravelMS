using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class User_IDCheckDALayer
    {
        public static IDataReader User_IDCheckDAL(string requestedUser_ID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand queryCmmnd = new SqlCommand("SELECT User_ID FROM EMPLOYEES WHERE User_ID=@User_ID");
            queryCmmnd.CommandType = CommandType.Text;

            queryCmmnd.Parameters.AddWithValue("@User_ID", requestedUser_ID);

            IDataReader resReader = travelMSysDB.ExecuteReader(queryCmmnd);
            return resReader;
        }
    }
}