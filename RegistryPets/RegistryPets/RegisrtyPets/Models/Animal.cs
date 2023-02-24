namespace RegistryPets.RegisrtyPets.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }

    }
}
