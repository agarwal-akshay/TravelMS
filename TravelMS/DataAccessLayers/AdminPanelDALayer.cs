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
    public class AdminPanelDALayer
    {
        public static IDataReader lockedAccounts()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand queryCmmnd = new SqlCommand("SELECT * FROM EMPLOYEES WHERE Access_Status = 'F'");
            queryCmmnd.CommandType = CommandType.Text;

            return travelMSysDB.ExecuteReader(queryCmmnd);
        }

        public static bool unlockAccount(string requestedUser_ID)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("Update EMPLOYEES Set Access_Status = 'T' WHERE User_ID = @User_ID ");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@User_ID", requestedUser_ID);
            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static bool addAgent(AgentModel model)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(ConnString.DBConnectionString);

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO AGENTS(Agent_ID,Password,Agent_Name,Creator_Admin_ID,Phone_Num,Address) VALUES (@Agent_ID,@Password,@Agent_Name,@Creator_Admin_ID,@Phone_Num,@Address)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Agent_ID", model.Agent_ID);
            insertCmmnd.Parameters.AddWithValue("@Password", "12d5ba628f5af19b9c8d5ccfe9283430");
            //insertCmmnd.Parameters.AddWithValue("@Access_Status",model.Access_Status);
            insertCmmnd.Parameters.AddWithValue("@Agent_Name", model.Agent_Name);
            insertCmmnd.Parameters.AddWithValue("@Creator_Admin_ID", model.Creator_Admin_ID);
            insertCmmnd.Parameters.AddWithValue("@Phone_Num", model.Phone_Num);
            insertCmmnd.Parameters.AddWithValue("@Address", model.Address);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }
    }
}