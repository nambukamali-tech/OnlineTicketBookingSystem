using OnlineTicketBookingSystem.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace OnlineTicketBookingSystem.Controllers
{
    public class UserController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TicketData"].ConnectionString;

        [HttpGet]
        public string Test() => "API WORKING";

        [HttpPost]
        public JsonResult Signup(UserSignup user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO UserSignup(FirstName, LastName, Email, Password, ConfirmPassword) VALUES (@FirstName, @LastName, @Email, @Password, @ConfirmPassword)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    return Json(new { success = rows > 0, message = rows > 0 ? "Signup Successfully" : "Signup Failed" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
