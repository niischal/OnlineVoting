using OnlineVoting.Models;

namespace OnlineVoting.Data.ViewModel
{
    public class VotersToBeVerifiedVM
    {
        public int VoterId { get; set; }
        public string VoterName { get; set; }
        public string UniqueId { get; set; }
        public string ElectionName { get; set; }

    }
}
