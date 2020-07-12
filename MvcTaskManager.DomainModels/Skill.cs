using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTaskManager.DomainModels
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public string SkillLevel { get; set; }
        public int Id { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}
