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
            // 1️⃣ Validate model
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
                // 2️⃣ Connection string from Web.config
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TicketData"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // 3️⃣ Insert query
                    string query = @"INSERT INTO UserSignup (FirstName, LastName, Email, Password, ConfirmPassword) 
                                     VALUES (@FirstName, @LastName, @Email, @Password, @ConfirmPassword)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    // 4️⃣ Add parameters
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);

                    // 5️⃣ Execute command asynchronously
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
        public JsonResult Login(UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid Data" });
            }
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TicketData"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM UserSignup WHERE Email=@Email AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        return Json(new { success = true, message = "Login Successful" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Invalid Email or Password" });
                    }
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
