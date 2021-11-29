namespace PartyFinderWEB.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel(string firstName, string lastName, DateTime age, Gender gender, string aspNetFK)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ProfileGender = gender;
            AspNetFK = aspNetFK;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Age { get; set; }
        public Gender ProfileGender { get; set; }
        public string AspNetFK { get; set; }

    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
