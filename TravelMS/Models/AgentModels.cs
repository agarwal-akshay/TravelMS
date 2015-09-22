using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMS.Models
{
    public class TicketBooking
    {
        [StringLength(30, ErrorMessage = "Ticket booking ID must be maximum 30 digits long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Booking ID")]
        public string Ticket_Booking_ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Travel request ID must be maximum 30 digits long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Request ID")]
        public string Travel_Request_ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Ticket details must be maximum 50 digits long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Details")]
        public string Ticket_Details { get; set; }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Booking Status")]
        public string Booking_Status { get; set; }
    }
}