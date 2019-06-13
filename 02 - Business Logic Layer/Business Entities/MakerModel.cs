using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class MakerModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing maker's name.")]
        public string makerName { get; set; }
    }
}
