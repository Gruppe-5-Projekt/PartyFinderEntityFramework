using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.ModelLayers
{
    public class Profile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public bool IsBanned { get; set; }
        public string Description { get; set; }


        public bool IsProfileEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(FirstName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Profile()
        {
            
        }

        public Profile(string firstName, string lastName, int age, string gender, string email,
            string phoneNo, string password, bool isBanned, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Email = email;
            PhoneNo = phoneNo;
            Password = password;
            IsBanned = isBanned;
            Description = description;
        }

        public Profile(int id, string firstName, string lastName, int age, string gender, string email, 
            string phoneNo, string password, bool isBanned, string description) : this(firstName, lastName, 
                age, gender, email, phoneNo, password, isBanned, description)
        {
            ID = id;
        }
    }
}
