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
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please set your birth date.")]
        [Display(Name = "Birth date")]
        public DateTime Age { get; set; }
        [Required(ErrorMessage = "Please specify your gender.")]
        [Display(Name = "Gender")]
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
