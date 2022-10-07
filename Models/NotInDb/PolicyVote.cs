namespace OnlineVoting.Models
{
    public class PolicyVote
    {
        public int Id { get; set; }  
        public virtual string Vote { get; set; }

        public virtual int eId { get; set; }
    }
}
