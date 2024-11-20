using System.Text.Json;

namespace CqrsSample.Framework.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
