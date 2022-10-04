using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public virtual List<UserElection> UserElections { get; set; }

        public virtual List<Voter> Voter { get; set; }
        //public virtual List<VotersToBeVerified> VotersToBeVerified { get; set; }
    }
}
