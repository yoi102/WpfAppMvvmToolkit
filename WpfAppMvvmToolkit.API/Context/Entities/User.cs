using System.ComponentModel.DataAnnotations;

namespace WpfAppMvvmToolkit.API.Context.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Account { get; set; }
        [Required]
        public string? Password { get; set; }

        public List<UserData>? UserData { get; set; }
    }
}
