using OnlineVoting.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }
        
        public string UniqueId { get; set; }
        [DefaultValue("true")]
        public bool canVote { get; set; }

        //Relationships

        //Election
        public int? ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election? Election { get; set; }

        //User
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //VerificationRequest
        public int? ReqId { get; set; }
        [ForeignKey("NotiId")]
        public VoterRegistration? Noti { get; set; }
    }  
}
