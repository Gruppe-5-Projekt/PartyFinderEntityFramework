namespace PartyFinderService.DTO.ProfileDTO
{
    public class ProfileDataCreateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool IsBanned { get; set; }
        public string AspNetFK { get; set; }

        public ProfileDataCreateDTO() { }

        public ProfileDataCreateDTO(string firstName, string lastName, DateTime age, string gender, string aspNetFK)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            IsBanned = false;
            AspNetFK = aspNetFK;
        }
    }
}


