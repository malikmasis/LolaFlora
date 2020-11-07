using LolaFlora.Data.Base;
using System.Text.Json.Serialization;

namespace LolaFlora.Data.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
