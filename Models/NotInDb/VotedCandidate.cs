namespace OnlineVoting.Models
{
    public class VotedCandidate
    {
        public virtual List<int> VotedCandidates{ get; set; }
        public virtual int eId { get; set; }
    }
}
