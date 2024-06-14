using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JojoAPI.Model
{
    [Table("Stand")]
    public class Stand
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public string Reference { get; set; }


    }
}
