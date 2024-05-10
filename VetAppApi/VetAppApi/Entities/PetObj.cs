namespace VetAppApi.Entities
{
    public class PetObj
    {
        public int IdPet { get; set; } = 0;
        public string petName { get; set; } = string.Empty;
        public string petSpecies { get; set; } = string.Empty;
        public int IdClient { get; set; } = 0;
        public string birthDate { get; set; } = string.Empty;

    }
}