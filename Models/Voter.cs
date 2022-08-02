using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Voter
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Firstname { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string LastName { get; set; }
        public bool IsValid { get; set; }
        public string UniqueId { get; set; }

        //Relationships

        //Election
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }
    }  
}
