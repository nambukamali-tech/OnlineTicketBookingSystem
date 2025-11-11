using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBookingSystem.Models
{
    public class Booking
    {
        [Required(ErrorMessage ="Travel ID is Mandatory")]
        public int TravelId { get; set; }
        [Required(ErrorMessage ="Departure Location is required")]
        public string From { get; set; }
        [Required(ErrorMessage ="Destination Location is required")]
        public string To { get; set; }
        [Required(ErrorMessage ="Members should be between 1 and 10")]
        public int Members { get; set; }
        [Required(ErrorMessage ="Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Travel Date is required")]
        public DateTime TravelDate { get; set; }
    }
}