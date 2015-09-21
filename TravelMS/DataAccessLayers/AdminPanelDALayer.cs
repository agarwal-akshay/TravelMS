using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class AdminPanelDALayer
    {
        public static SqlDataReader lockedAccounts()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand queryCmmnd = new SqlCommand("SELECT * FROM EMPLOYEES WHERE Access_Status = 'F'");
            queryCmmnd.CommandType = CommandType.Text;

            SqlDataReader resReader = (SqlDataReader)travelMSysDB.ExecuteReader(queryCmmnd);
            return resReader;
        }
    }
}