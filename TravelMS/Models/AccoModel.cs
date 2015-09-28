using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMS.Models
{
    public class AccoModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Request ID")]
        public string Travel_Request_ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "YYYY/MM/DD", ApplyFormatInEditMode = true)]
        [Display(Name = "CheckIn Date")]
        public DateTime Check_in_Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "YYYY/MM/DD", ApplyFormatInEditMode = true)]
        [Display(Name = "CheckOut Date")]
        public DateTime Check_out_Date { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Room_Type")]
        public string Room_Type { get; set; }
    }
}