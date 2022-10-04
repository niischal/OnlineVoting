using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class VoterRegistration
    {
        [Key]
        public int ReqId { get; set; }

        public string UniqueId { get; set; }

        //Election
        [Required]
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }

        //User
        public int VoterId { get; set; }
        [ForeignKey("VoterId")]
        public Voter Voter { get; set; }

    }
}
