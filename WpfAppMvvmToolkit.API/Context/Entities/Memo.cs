namespace WpfAppMvvmToolkit.API.Context.Entities
{
    public class Memo : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
