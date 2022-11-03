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
        public static LoginStatus Login(LoginUserRequest cred)
        {
            var status = new LoginStatus();
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
                   if (result.Password.Trim() == cred.Password.ToLower())
                    {
                        int userID = Convert.ToInt32(string.Format("{0}{1}",result.Year, result.UserID));
                      
                        status.statusCode = 00;
                        status.status = "Successfull";
                        status.userID = userID;

                    }
                    else {
                        status.statusCode = 01;
                        status.status = "Invalid Username and Password Match";
                        status.userID = 0;

                    }

                }
            }
            return status;
        }

        public static CreateUserResponse Create(UserRequest customer)
        {
            var response = new CreateUserResponse();
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
                    response.StatusCode = 00;
                    response.Status = "Successfull";
                    response.CustomerID = userID;
                }
                else
                {
                    response.StatusCode = 02;
                    response.Status = "Successfull | but couldnt generate ID";
                    response.CustomerID = 0;
                }
              
            }
            else {
                response.StatusCode = 01;
                response.Status = "request was  unsuccessful";
            }
            return response;
        }

        internal static CreateUserResponse ValidateAccount(string email)
        {
            var response = new CreateUserResponse();
            string result = string.Empty;
            User user = UserData.GetUserUsingEmail(email);
      
                if (user.UserID == 0)
                {
                    response.StatusCode = 01;
                    response.Status = "request was  unsuccessful. User not found";
                    return response;
                }
           
            user.Email = email;
            user.AccountVerified = 0;
            user.Date_Verified = DateTime.Now;

            result = UserData.UpdateData(user);
            if (result == "00")
            {
                response.StatusCode = 00;
                response.Status = "Successfull";

            }
            else
            {
                response.StatusCode = 01;
                response.Status = "request was  unsuccessful";
            }
            return response;
        }
    }
}
