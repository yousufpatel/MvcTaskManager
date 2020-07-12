using System;
using System.Collections.Generic;
using System.Text;

namespace MvcTaskManager.ViewModels
{
    public class UserViewModel
    {

        public int Id { get; set; }

        public PersonName PersonName { get; set; }
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int CountryID { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public int RoleId { get; set; }

        public List<SkillViewModel> Skills { get; set; }


    }

    public class PersonName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
