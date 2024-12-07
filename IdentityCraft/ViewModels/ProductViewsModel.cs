using System.ComponentModel.DataAnnotations;

namespace IdentityCraft.ViewModels
{
    public class ProductViewsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
    }
}
