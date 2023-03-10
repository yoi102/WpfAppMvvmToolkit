using System.ComponentModel.DataAnnotations;

namespace WpfAppMvvmToolkit.API.Context.Entities
{
    public class User : BaseEntity
    {
       
        [Required]
        public string? Account { get; set; }
        [Required]
        public string? Password { get; set; }

        public List<Memo>? Memos { get; set; }
        public Profile? Profile { get; set; }
    }
}
