using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TravelMS
{
    public class LoginBizLayer
    {
        public static bool LoginUserBiz(Models.LoginModel userData, string role)
        {
            MD5 hasher = MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.UTF8.GetBytes(userData.Password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            userData.Password = sBuilder.ToString();

            if (role.Equals("Emp"))
            {
                if (LoginDALayer.LoginUserDAL(userData))
                    return true;
            }
            else if (role.Equals("Admin"))
            {
                if (LoginDALayer.LoginAdminDAL(userData))
                    return true;
            }
            else if (role.Equals("Agent"))
            {
                if (LoginDALayer.LoginAgentDAL(userData))
                    return true;
            }
            return false;
        }
    }
}