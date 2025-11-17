using System.Text.Json.Serialization;

namespace Orion_API.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        [JsonIgnore]
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
