namespace WpfAppMvvmToolkit.API.Context.Entities
{
    public class UserData : BaseEntity
    {
        public string? Description { get; set; }


        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
