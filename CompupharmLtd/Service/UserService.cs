using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompupharmLtd.Service
{
    public class UserService
    {
        public static Response Login(LoginUserRequest cred)
        {
            var status = new Response();
            if (cred.UserName != null)
            {
                LoginUser result = UserData.LoginData(cred.UserName);
                if (result.UserName == null)
                {
                    status.statusCode = 02;
                    status.status = "User Account Doesnt exist";
                }
                else {
                   // Regex.Replace(result.UserName, @"\s+", "");
                   if (result.Password.Trim().ToLower() == cred.Password.ToLower())
                    {
                        string year = "2022";
                        int userID = Convert.ToInt32(string.Format("{0}{1}",year, result.UserID));
                      
                        status.statusCode = 00;
                        status.status = "Successfull";
                        status.data = userID;

                    }
                    else {
                        status.statusCode = 01;
                        status.status = "Invalid Username and Password Match";
                        status.data = 0;

                    }

                }
            }
            return status;
        }

        public static Response Create(UserRequest customer)
        {
            var response = new Response();
            string result = string.Empty;
            User user = new User
            {
                CompanyName=customer.CompanyName,
                CompanyPhone=customer.CompanyPhone,
              CompanyAddress = customer.CompanyAddress,
              Email =customer.Email,
              Username = customer.Username,
              Password = customer.Password,
              CompanyCertificate=customer.CompanyCertificate,
              
            };
             result = UserData.CreateData(user);
            if (result =="00")
            {  
                LoginUser user1 = UserData.LoginData(user.Username);
                if (user1.UserID != 0)
                {
                    int userID = Convert.ToInt32(string.Format("{0}{1}", user1.Year, user1.UserID));
                    response.statusCode = 00;
                    response.status = "Successfull";
                    response.data = userID;
                }
                else
                {
                    response.statusCode = 02;
                    response.status = "Successfull | but couldnt generate ID";
                    response.data = 0;
                }
              
            }
            else {
                response.statusCode = 01;
                response.status = "request was  unsuccessful";
            }
            return response;
        }

        internal static Response ValidateAccount(string email)
        {
            var response = new Response();
            string result = string.Empty;
            User user = UserData.GetUserUsingEmail(email);
      
                if (user.UserID == 0)
                {
                    response.statusCode = 01;
                    response.status = "request was  unsuccessful. User not found";
                    return response;
                }
           
            user.Email = email;
            user.AccountVerified = 0;
            user.Date_Verified = DateTime.Now;

            result = UserData.UpdateData(user);
            if (result == "00")
            {
                response.statusCode = 00;
                response.status = "Successfull";

            }
            else
            {
                response.statusCode = 01;
                response.status = "request was  unsuccessful";
            }
            return response;
        }
    }
}
