using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TravelMSWebService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        public bool CheckUser(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return false;
            var resReader = User_IDCheckDAL(userName);
            if (resReader.Read())
            {
                Console.WriteLine(resReader.GetString(0));
                resReader.Close();
                return false;
            }
            return true;
        }

        private IDataReader User_IDCheckDAL(string userName)
        {

            SqlDatabase travelMSysDB = new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["TravelMSConnString"].ConnectionString);// (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");//new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["TravelMSConnString"].ConnectionString);

            SqlCommand queryCmmnd = new SqlCommand("SELECT User_ID FROM EMPLOYEES WHERE User_ID=@User_ID");
            queryCmmnd.CommandType = CommandType.Text;

            queryCmmnd.Parameters.AddWithValue("@User_ID", userName);

            IDataReader resReader = travelMSysDB.ExecuteReader(queryCmmnd);
            return resReader;
        }
    }
}