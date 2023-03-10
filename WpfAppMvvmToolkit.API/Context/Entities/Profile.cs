using System.ComponentModel.DataAnnotations;

namespace WpfAppMvvmToolkit.API.Context.Entities
{
    public class Profile : BaseEntity
    {
        public string? NetName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
