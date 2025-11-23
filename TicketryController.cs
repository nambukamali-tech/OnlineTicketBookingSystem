using OnlineTicketry.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicketry.Controllers
{
    public class TicketryController : Controller
    {
        [HttpPost]
        public async Task<JsonResult> Signup(UserSignup user)
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();
                return Json(new { success = false, errors });
            }

            try
            {
                // Connection string from Web.config
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TicketData"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Insert query
                    string query = @"INSERT INTO UserSignup (FirstName, LastName, Email, Password, ConfirmPassword) 
                                     VALUES (@FirstName, @LastName, @Email, @Password, @ConfirmPassword)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);

                    // Execute command asynchronously
                    await con.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    con.Close();

                    return Json(new
                    {
                        success = rows > 0,
                        message = rows > 0 ? "Signup Successful" : "Signup Failed"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]//Login Page Controller
        public JsonResult Login(UserSignup user)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicketBookingSystem;Integrated Security=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM UserSignup WHERE Email=@Email AND Password=@Password";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (count > 0)
                    {
                        return Json(new
                        {
                            success = true,
                            message = "Login successful!"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Invalid email or password"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Server error: " + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
