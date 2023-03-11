using RestSharp;

namespace WpfAppMvvmToolkit.Core.Models
{
    public class BaseRequest
    {
        public Dictionary<string, string>? Parameters { get; set; } 
        public List<object>? Bodies { get; set; }
        public List<string>? Files { get; set; }
        public Method Method { get; set; }
        public string? Action { get; set; }
        public string? Controller { get; set; }
    }
}