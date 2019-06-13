using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing first name.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Missing last name.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Missing user name.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Missing password.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Missing phone number.")]
        public string phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid E-Mail address.")]
        public string email { get; set; }                   // optional

        public DateTime? birthDay { get; set; }             // optional

        [Required(ErrorMessage = "Missing user role.")]
        public string role { get; set; }

    }
}
