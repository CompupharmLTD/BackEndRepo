using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyPhone { get; set; }
        public string Email { get; set; }
        public string CompanyCertificate { get; set; }
        public string Year { get; set; }
        public int AccountVerified { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Updated { get; set; }
        public DateTime Date_Verified { get; set; }
    }
    public class UserRequest
    {
       // public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyPhone { get; set; }
        public string Email { get; set; }
        public string CompanyCertificate { get; set; }
       // public int AccountVerified { get; set; }
       // public DateTime Date_Created { get; set; }
        //public DateTime Date_Updated { get; set; }
    }

    public class LoginUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
    public class CreateUserResponse
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public User Customer { get; set; }
    }
    }
