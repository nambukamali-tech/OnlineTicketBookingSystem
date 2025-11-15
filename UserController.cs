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

        // Allow CORS + Handle OPTIONS requests
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");

            // Handle preflight OPTIONS request
            if (Request.HttpMethod == "OPTIONS")
            {
                filterContext.Result = new HttpStatusCodeResult(200);
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        // ===================== SIGNUP ======================
        [HttpPost]
        public JsonResult Signup(UserSignup user)
        {
            try
            {
                if (user == null)
                {
                    return Json(new { success = false, message = "Invalid JSON received" },
                        JsonRequestBehavior.AllowGet);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO UserSignup
                                     (FirstName, LastName, Email, Password, ConfirmPassword)
                                     VALUES
                                     (@FirstName, @LastName, @Email, @Password, @ConfirmPassword)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        return Json(new { success = true, message = "Signup Successfully" }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { success = false, message = "Signup Failed" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // ===================== LOGIN ======================
        [HttpPost]
        public JsonResult Login(UserLogin user)
        {
            try
            {
                if (user == null)
                {
                    return Json(new { success = false, message = "Invalid JSON received" },
                        JsonRequestBehavior.AllowGet);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT COUNT(*) FROM UserSignup 
                                     WHERE Email = @Email AND Password = @Password";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                        return Json(new { success = true, message = "Login Successfully!" }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { success = false, message = "Invalid Email or Password" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
