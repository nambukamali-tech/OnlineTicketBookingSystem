using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using OnlineTicketry.Models;

namespace OnlineTicketry.Controllers
{
    public class AdminController : Controller
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineTicketBookingSystem;Integrated Security=True";

        [HttpGet]
        public JsonResult DashboardStats()
        {
            try
            {
                BookingInfo info = new BookingInfo();
                List<BookingDetails> allBookings = new List<BookingDetails>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Total Users
                    var cmdUsers = new SqlCommand("SELECT COUNT(*) FROM Booking", con);
                    info.TotalUsers = Convert.ToInt32(cmdUsers.ExecuteScalar());

                    // Fetch all bookings (you can filter for today if needed)
                    var cmdBookings = new SqlCommand(@"
                        SELECT Travel_From, Travel_To, Members, Price, Total_Amount, Date_of_Travel
                        FROM Booking
                        ORDER BY Date_of_Travel DESC
                    ", con);

                    using (SqlDataReader reader = cmdBookings.ExecuteReader())
                    {
                        decimal totalRevenueToday = 0;
                        int totalBookingsToday = 0;
                        DateTime today = DateTime.Today;

                        while (reader.Read())
                        {
                            var dateOfTravel = Convert.ToDateTime(reader["Date_of_Travel"]);

                            BookingDetails b = new BookingDetails
                            {
                                

                                TravelFrom = reader["Travel_From"].ToString(),
                                TravelTo = reader["Travel_To"].ToString(),
                                Members = Convert.ToInt32(reader["Members"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                TotalAmount = Convert.ToDecimal(reader["Total_Amount"]),
                                DateOfTravel = dateOfTravel
                            };

                            allBookings.Add(b);

                            // Count today bookings & revenue
                            if (dateOfTravel.Date == today)
                            {
                                totalBookingsToday++;
                                totalRevenueToday += b.TotalAmount;
                            }
                        }

                        info.TotalBookingsToday = totalBookingsToday;
                        info.TotalRevenueToday = totalRevenueToday;
                    }
                }

                return Json(new { success = true, info, allBookings }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
