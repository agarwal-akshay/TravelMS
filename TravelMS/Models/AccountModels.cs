using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace TravelMS.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string User_ID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Range(100000,999999,ErrorMessage = "The Employee ID must be 6 digits long.")]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [Display(Name = "Employee ID")]
        public int Emp_ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Employee Name must be maximum 30 digits long.", MinimumLength = 1)]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [DataType(DataType.Text)]
        [Display(Name = "Employee Name")]
        public string Emp_Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The User ID must be maximum 30 digits long.", MinimumLength = 1)]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "This field can't have spaces.")]
        [DataType(DataType.Text)]
        [Display(Name = "User ID")]
        public string User_ID { get; set; }

        public string Access_Status { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Password must be maximum 30 digits long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[A-Z])(?!.*\s).*$",
                    ErrorMessage = "Password must have at least 1 special character(!@#$%^&*), 1 upper case character and a digit.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "YYYY/MM/DD", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "YYYY/MM/DD", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Joining")]
        public DateTime Date_of_Joining { get; set; }

        [Required]
        [Display(Name = "Job Level")]
        public int Job_Level { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Job Location")]
        public string Job_Location { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
