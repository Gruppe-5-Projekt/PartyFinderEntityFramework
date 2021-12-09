using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "FirstName"), Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "LastName"), Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Display(Name = "Age"), Required(ErrorMessage = "Please set your birth date.")]
        public DateTime Age { get; set; }
        [Display(Name = "Gender"), Required(ErrorMessage = "Please specify your gender.")]
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
