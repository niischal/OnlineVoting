
using OnlineVoting.Data;
using OnlineVoting.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Election : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Candidate Name is Required")]
        [Display(Name = "Election Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string ElectionName { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Election Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Election End Date is Required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "varchar(200)")]
        public string? Decription { get; set; }


        //Enum
        [Display(Name = "Election Type")]
        public ElectionType ElectionType { get; set; }
      
        [Display(Name = "Election State")]
        public ElectionState ElectionState { get; set; }


        //Relationships
        public virtual List<Voter> Voters { get; set; }

        public virtual List<Policy> Policies { get; set; }
        public virtual List<Position> Positions { get; set; }


    }
}
