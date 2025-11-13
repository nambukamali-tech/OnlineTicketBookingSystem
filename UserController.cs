using OnlineTicketBookingSystem.Models;//Add namespace for extract the datas from Models
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace OnlineTicketBookingSystem.Controllers
{
    //In this User controller we handle both signup and login informations of users
    public class UserController : Controller
    {
        
       string connectionString = ConfigurationManager.ConnectionStrings["TicketData"].ConnectionString;

        //Signup : POST Method
        [HttpPost]
        public JsonResult Signup(UserSignup user)//Here the "user" is an object for UserSignup Model class
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))//Take the Sql Connection from connectionString "webconfig"
                {
                    string query = "insert into UserSignup(FirstName , LastName , Email , Password , ConfirmPassword) values (@FirstName , @LastName , @Email , @Password , @ConfirmPassword) ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);
                    con.Open();//Connection open
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();//Connection closed
                    if (rows > 0)

                        return Json(new { success = true, message = "Signup Successfully" });
                    else
                        return Json(new { success = false, message = "Signup Failed" });

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            
        }

        //Login : POST Method
        [HttpPost]//It means the Page Only runs when the frontend react starts the Post request
        public JsonResult Login(UserLogin user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "Select count(*) from UserSignup where Email = @Email and Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (count > 0)
                        return Json(new { success = true, message = "Login Successfully!" });
                    else
                        return Json(new { success = false, message = "Login failed" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

    }
}