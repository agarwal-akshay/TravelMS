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
        public static bool User_IDCheckDAL(string requestedUser_ID)
        {
            if (string.IsNullOrWhiteSpace(requestedUser_ID))
                return false;
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand queryCmmnd = new SqlCommand("SELECT User_ID FROM EMPLOYEES WHERE User_ID=@User_ID");
            queryCmmnd.CommandType = CommandType.Text;

            queryCmmnd.Parameters.AddWithValue("@User_ID", requestedUser_ID);

            IDataReader resReader = travelMSysDB.ExecuteReader(queryCmmnd);
            if (resReader.Read())
            {
                Console.WriteLine(resReader.GetString(0));
                return false;
            }
            return true;
        }
    }
}