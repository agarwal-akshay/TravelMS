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
        public List<string> Travel_Request_ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Claim Request ID must be maximum 30 characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Claim Request ID")]
        public string Claim_Request_ID { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage="Claim Amount must be greater than zero.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Claim Amount")]
        public int Claim_Amount { get; set; }

        [StringLength(50, ErrorMessage = "Please use only 50 or less characters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}