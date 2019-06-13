using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class FleetModel
    {
        public int carID { get; set; }

        [Required(ErrorMessage = "Missing model.")]
        public int modelID { get; set; }

        public ModelModel model { get; set; }

        [Required(ErrorMessage = "Missing license plate number.")]
        [Range(0, 99999999, ErrorMessage = "License plate should be up to 8 digits.")]
        public int licensePlate { get; set; }


    }
}
