namespace ForumSport.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        



        public virtual ApplicationUser? User { get; set; }
        public string? UserId { get; set; } // Foreign key to ApplicationUser
        public virtual Post? Post { get; set; }
        public int PostId { get; set; } // Foreign key to Post
    }
}
