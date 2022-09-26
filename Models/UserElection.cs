namespace OnlineVoting.Models
{
    public class UserElection
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ? ElectionId { get; set; }
        public Election Election { get; set; }
    }
}
