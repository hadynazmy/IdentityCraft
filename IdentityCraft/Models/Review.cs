using System.ComponentModel.DataAnnotations;

namespace IdentityCraft.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Rating should be between 1 and 5")]
        public int Rating { get; set; }
    }
}
