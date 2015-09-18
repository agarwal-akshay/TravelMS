using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TravelMS
{
    public class RegisterDALayer
    {
        public static bool RegisterUserDAL(Models.RegisterModel userData)
        {
            //Database travelMSysDB = EnterpriseLibraryContainer.Current.GetInstance<Database>("ConnectionStringCS");
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO EMPLOYEES ([User_ID],[Password],[Emp_ID],[Emp_Name],[Gender],[Date_of_Birth],[Date_of_Joining],[Job_Level],[Job_Location]) VALUES (@User_ID,@Password,@Emp_ID,@Emp_Name,@Gender,@Date_of_Birth,@Date_of_Joining,@Job_Level,@Job_Location)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@User_ID", userData.User_ID);
            insertCmmnd.Parameters.AddWithValue("@Password", userData.Password);
            //insertCmmnd.Parameters.AddWithValue("@Access_Status",userData.Access_Status);
            insertCmmnd.Parameters.AddWithValue("@Emp_ID", userData.Emp_ID);
            insertCmmnd.Parameters.AddWithValue("@Emp_Name", userData.Emp_Name);
            insertCmmnd.Parameters.AddWithValue("@Gender", userData.Gender);
            insertCmmnd.Parameters.AddWithValue("@Date_of_Birth", userData.Date_of_Birth);
            insertCmmnd.Parameters.AddWithValue("@Date_of_Joining", userData.Date_of_Joining);
            insertCmmnd.Parameters.AddWithValue("@Job_Level", userData.Job_Level);
            insertCmmnd.Parameters.AddWithValue("@Job_Location", userData.Job_Location);

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.WriteLine("rowsAffected " + rowsAffected);

            if (rowsAffected == 1)
                return true;
            return false;
        }
    }
}