using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcTaskManager.DomainModels
{
    public class Role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [Column(TypeName ="varchar(200)")]
        public string RoleName { get; set; }
    }
}
