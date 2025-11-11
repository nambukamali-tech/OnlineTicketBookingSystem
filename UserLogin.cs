using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBookingSystem.Models
{
    public class UserLogin
    {
        [Key]//Entity Framework Identify easily
        public int Id { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

    }
}