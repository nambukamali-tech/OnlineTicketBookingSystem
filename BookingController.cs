using OnlineTicketry.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicketry.Controllers
{
    public class BookingController : Controller
    {
        [HttpPost]
        public JsonResult SaveBooking(TicketBooking booking)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicketBookingSystem;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Booking 
                        (Travel_Id, Travel_From, Travel_To, Members, Price, Total_Amount, Date_of_Travel)
                        VALUES (@TravelId, @From, @To, @Members, @Price, @Total_Amount, @Date_of_Travel)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@TravelId", booking.Travel_Id);
                    cmd.Parameters.AddWithValue("@From", booking.Travel_From);
                    cmd.Parameters.AddWithValue("@To", booking.Travel_To);
                    cmd.Parameters.AddWithValue("@Members", booking.Members);
                    cmd.Parameters.AddWithValue("@Price", booking.Price);
                    cmd.Parameters.AddWithValue("@Total_Amount", booking.Total_Amount);
                    cmd.Parameters.AddWithValue("@Date_of_Travel", booking.Date_of_Travel);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return Json(new
                    {
                        success = rows > 0,
                        booking = booking
                    }, JsonRequestBehavior.AllowGet);
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
