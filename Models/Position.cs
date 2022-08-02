using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PositionTitle { get; set; }
        public string? Description { get; set; }

        //Relationship
        public List<Candidate> Candidates { get; set; }

        //Election
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }
    }
}
