using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class LoginDALayer
    {
        public static bool LoginUserDAL(Models.LoginModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand selectCmmnd = new SqlCommand("SELECT [Password] FROM EMPLOYEES WHERE [User_ID]=@User_ID");
            selectCmmnd.CommandType = CommandType.Text;

            selectCmmnd.Parameters.AddWithValue("@User_ID", userData.User_ID);
            
            string pHash = travelMSysDB.ExecuteScalar(selectCmmnd).ToString();
            
            if (pHash.Equals(userData.Password))
                return true;
            return false;
        }
    }
}