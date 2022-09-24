using OnlineVoting.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Policy : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Policy Title is Required")]
        [Display(Name = "Policy Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Policy Title must be between 3 and 50 chars")]
        [Column(TypeName = "varchar(100)")]
        public string PolicyTitle { get; set; }


        [Column(TypeName = "varchar(200)")]
        public string? PolicyDescription { get; set; }
        public int PolicyYesVote { get; set; }
        public int PolicyNoVote { get; set; }


        //Relationships


        //Election
        public int ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election Election { get; set; }

    }
}
