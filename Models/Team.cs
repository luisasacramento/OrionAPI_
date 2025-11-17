using System.Text.Json.Serialization;

namespace Orion_API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LeaderId { get; set; } // agora opcional

        [JsonIgnore] // evita o loop
        public Leader? Leader { get; set; }
        public ICollection<Member>? Members { get; set; }
    }
}
