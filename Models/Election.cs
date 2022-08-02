
using OnlineVoting.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Election
    {
        [Key]
        public int ElectionId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ElectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Decription { get; set; }


        //Enum
        public ElectionType ElectionType { get; set; }
        public ElectionState ElectionState { get; set; }


        //Relationships
        public List <Voter> Voters { get; set; }
        public List <Policy> Policies { get; set; }
        public List <Position> Positions { get; set; }


    }
}
