using System.ComponentModel.DataAnnotations;

namespace IdentityCraft.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
    }
}
