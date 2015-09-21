using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMS.Models
{
    public class NewTravelRequestModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Travel Request ID", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Request ID")]
        public string Travel_Request_ID { get; set; }

        [Required]
        [Range(100000, 999999)]
        [Display(Name = "Employee ID")]
        public int Emp_ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Trip Name", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Name")]
        public string Trip_Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Travel Type (Purpose)", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Type (Purpose)")]
        public string Travel_Type_Purpose { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Travel")]
        public DateTime Travel_Date { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Mode of Travel", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Mode of Travel")]
        public string Mode_of_Travel { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Travel Class", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Class")]
        public string Travel_Class { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Source City", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Source City")]
        public string Source_City { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Destination City", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Destination City")]
        public string Destination_City { get; set; }

        [Required]
        [Range(0, 23)]
        public int Travel_Time_hh { get; set; }

        [Required]
        [Range(0, 59)]
        public int Travel_Time_mm { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "First Level Approver", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "First Level Approver")]
        public string First_Level_Approver{ get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Agent ID", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Agent ID")]
        public string Agent_ID { get; set; }

        public string Request_Status { get; set; }

        public string Acco_Status { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Remarks", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}