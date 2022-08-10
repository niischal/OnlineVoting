using OnlineVoting.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Position : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Position Title is Required")]
        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? Description { get; set; }

        //Relationship
        public virtual List<Candidate> Candidates { get; set; }

        //Election
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }
    }
}
