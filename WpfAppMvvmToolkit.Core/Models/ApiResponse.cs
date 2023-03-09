namespace WpfAppMvvmToolkit.Core.Models
{
    public class ApiResponse
    {
        public string? Message { get; set; }
        public object? Result { get; set; }
        public bool Status { get; set; }
    }

    public class ApiResponse<T>
    {
        public string? Message { get; set; }
        public T? Result { get; set; }
        public bool Status { get; set; }
    }
}