using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JojoAPI.Model
{
    [Table("Character")]
    public class Character
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SeasonDebut { get; set; }
        public virtual Stand? Stand { get; set; }

        public Role Role { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Jojo,
        JoBro,
        Villain
    }
}
