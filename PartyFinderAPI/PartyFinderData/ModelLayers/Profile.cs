using System;
using System.Collections.Generic;

namespace PartyFinderData.ModelLayers
{
    public partial class Profile
    {
        public Profile()
        {
        }
        public Profile(string firstName, string lastName, DateTime age, string gender, string description, bool isBanned, string aspNetFK)
        {
           FirstName = firstName;
           LastName = lastName;
           Age = age;
           Gender = gender;
           Description = description;
           IsBanned = isBanned;
           AspNetUserForeignKey = aspNetFK;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Age { get; set; }
        public string Gender { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsBanned { get; set; }
        public string AspNetUserForeignKey { get; set; } = null!;

        public virtual AspNetUser AspNetUserForeignKeyNavigation { get; set; } = null!;
        public virtual Business Business { get; set; } = null!;
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<ReportUser> ReportUserAccusers { get; set; }
        public virtual ICollection<ReportUser> ReportUserOffenders { get; set; }
    }
}
