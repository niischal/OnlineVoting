using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class VotersToBeVerified
    {
        [Key]
        public int Id { get; set; }

        //Relatonship
        public List<Voter> Voters { get; set; }


        //User
        public string AdminId;
        [ForeignKey("AdminId")]
        public ApplicationUser Admin { get; set; }
    }
}
