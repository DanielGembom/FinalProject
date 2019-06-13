using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class ModelModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing maker.")]
        public int makerID { get; set; }

        public MakerModel maker { get; set; }

        [Required(ErrorMessage = "Missing model's name.")]
        public string modelName { get; set; }

        [Required(ErrorMessage = "Missing Daily price.")]
        [Range(0, 10000, ErrorMessage = "Daily price cannot be less than 0 or more than 10,000.")]
        public decimal dailyPrice { get; set; }

        [Required(ErrorMessage = "Missing model's picture.")]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "File type does not supported.")]
        public string picture { get; set; }

    }
}
