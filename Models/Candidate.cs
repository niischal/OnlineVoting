using OnlineVoting.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Candidate : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Candidate Photo")]
        [Required(ErrorMessage = "Candidate Photo is Required")]
        public string CandidateIcon { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage ="Candidate Name is Required")]
        [StringLength(50,MinimumLength =3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string CandidateName { get; set; }
        public int CandidateVoteCount { get; set; }

        //Relationships

        //Position
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

    }
}
