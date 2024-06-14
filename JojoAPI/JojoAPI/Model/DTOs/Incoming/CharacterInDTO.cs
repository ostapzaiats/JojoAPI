namespace JojoAPI.Model.DTOs.Incoming
{
    public class CharacterInDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SeasonDebut { get; set; }
        public int StandId { get; set; }
        public Role Role { get; set; }
    }
}
