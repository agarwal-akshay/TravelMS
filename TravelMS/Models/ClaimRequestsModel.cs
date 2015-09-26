using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMS.Models
{
    public class ClaimRequestsModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Travel Request ID")]
        public string Travel_Request_ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Claim Request ID must be maximum 30 characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Claim ID")]
        public string Claim_ID { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Claim Amount must be greater than zero.")]
        [Display(Name = "Claim Amount")]
        public int Claim_Amount { get; set; }

        public int Settled_Amount { get; set; }
        public string Admin_Remarks { get; set; }
        public char Claim_Status { get; set; }
        public string Admin_ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please use only 30 or less characters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}