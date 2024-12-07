using System.ComponentModel.DataAnnotations;

namespace IdentityCraft.ViewModels
{
    public class ReviewViewsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Rating should be between 1 and 5")]
        public int Rating { get; set; }
    }
}
