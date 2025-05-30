namespace ForumSport.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        



        public virtual ApplicationUser? User { get; set; }
        public string? UserId { get; set; } // Foreign key to ApplicationUser

        public virtual ApplicationUser? ToUser { get; set; }
        public string? ToUserId { get; set; }

    }
}
