using System.Text.Json.Serialization;

namespace Orion_API.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // inicializado
        public string Role { get; set; } = string.Empty; // inicializado

        [JsonIgnore] //
        public ICollection<Team>? Teams { get; set; }
    }
}
