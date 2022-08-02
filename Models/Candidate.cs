using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string CandidateIcon { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CandidateName { get; set; }
        public int CandidateVoteCount { get; set; }

        //Relationships

        //Position
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

    }
}
