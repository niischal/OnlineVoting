using OnlineVoting.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVoting.Models
{
    public class Voter : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 chars")]
        public string Firstname { get; set; }


        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 chars")]
        public string LastName { get; set; }

        [Display(Name = "Valid")]
        public bool IsVarified { get; set; }


        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Unique Id is Required")]
        [Display(Name = "Unique Id")]
        
        public string UniqueId { get; set; }

        //Relationships

        //Election
        public int? ElectionId { get; set; }
        [ForeignKey("ElectionId")]
        public Election? Election { get; set; }
    }  
}
