using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Policy
    {
        [Key]
        public int PolicyID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PolicyTitle { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? PolicyDescription { get; set; }
        public int PolicyYesVote { get; set; }


        //Relationships


        //Election
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }

    }
}
