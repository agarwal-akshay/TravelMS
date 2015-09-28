using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TravelMS.Models;

namespace TravelMS
{
    public class LoginDALayer
    {
        public static bool LoginUserDAL(LoginModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);// (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand selectCmmnd = new SqlCommand("SELECT [Password] FROM EMPLOYEES WHERE [User_ID]=@User_ID");
            selectCmmnd.CommandType = CommandType.Text;

            selectCmmnd.Parameters.AddWithValue("@User_ID", userData.User_ID);
            
            object pHash = travelMSysDB.ExecuteScalar(selectCmmnd);

            if (!(pHash == null))
            if (pHash.ToString().Equals(userData.Password))
                return true;
            return false;
        }

        public static bool LoginAdminDAL(LoginModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand selectCmmnd = new SqlCommand("SELECT [Password] FROM ADMINS WHERE [Admin_ID]=@User_ID");
            selectCmmnd.CommandType = CommandType.Text;

            selectCmmnd.Parameters.AddWithValue("@User_ID", userData.User_ID);

            object pHash = travelMSysDB.ExecuteScalar(selectCmmnd);

            if(!(pHash==null))
                if (pHash.ToString().Equals(userData.Password))
                return true;
            return false;
        }

        public static bool LoginAgentDAL(LoginModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand selectCmmnd = new SqlCommand("SELECT [Password] FROM AGENTS WHERE [Agent_ID]=@User_ID");
            selectCmmnd.CommandType = CommandType.Text;

            selectCmmnd.Parameters.AddWithValue("@User_ID", userData.User_ID);

            object pHash = travelMSysDB.ExecuteScalar(selectCmmnd);

            if (!(pHash == null))
                if (pHash.ToString().Equals(userData.Password))
                    return true;
            return false;
        }
    }
}