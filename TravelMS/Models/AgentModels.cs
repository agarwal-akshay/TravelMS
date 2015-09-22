using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;


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


    public class AgentModel
    {
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "The Agent ID must be maximum 30 characters long.")]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [DataType(DataType.Text)]
        [Display(Name = "Agent ID")]
        public string Agent_ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "The Agent Name must be maximum 30 characters long.")]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [DataType(DataType.Text)]
        [Display(Name = "Agent Name")]
        public string Agent_Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "The Agent Name must be maximum 30 characters long.")]
        //[RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "This field should have exactly 10 digits.")]
        [Display(Name = "Phone")]
        public string Phone_Num { get; set; }

        [Required]
        public string Creator_Admin_ID { get; set; }
    }
}