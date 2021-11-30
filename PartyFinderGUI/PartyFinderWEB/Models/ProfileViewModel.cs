namespace PartyFinderWEB.Models
{
    public class ProfileViewModel
    {

        public ProfileViewModel(string firstName, string lastName, DateTime age, string gender, string description, bool isBanned, string aspNetFK)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Description = description;
            IsBanned = isBanned;
            AspNetFK = aspNetFK;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; } 
        public bool IsBanned { get; set; }
        public string AspNetFK { get; set; }

    }

    //public enum Gender
    //{
    //    Male,
    //    Female,
    //    Other
    //}
}
