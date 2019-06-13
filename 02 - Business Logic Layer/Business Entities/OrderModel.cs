using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class OrderModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing car.")]
        public int carID { get; set; }

        [Required(ErrorMessage = "Missing user.")]
        public int userID { get; set; }

        public UserModel user { get; set; }

        [Required(ErrorMessage = "Missing starting date of rental period.")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "Missing ending date of rental period.")]
        public DateTime endDate { get; set; }

        [Required(ErrorMessage = "Missing total price.")]
        [Range(0, ulong.MaxValue, ErrorMessage = "Total price cannot be less than 0.")]    // Validation for minimum, not for maximum.
        public decimal totalPrice { get; set; }
    }
}
