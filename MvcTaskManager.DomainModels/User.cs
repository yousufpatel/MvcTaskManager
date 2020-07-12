using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MvcTaskManager.DomainModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required, Column(TypeName = "varchar(50)")] 
        public string UserName { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Gender { get; set; }

        public int CountryID { get; set; }

        public bool ReceiveNewsLetters { get; set; }
        
        public int RoleId { get; set; }

    }
}
